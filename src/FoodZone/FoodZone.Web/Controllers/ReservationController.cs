using FoodZone.Models.Common;
using FoodZone.Services.IServices;
using FoodZone.Web.ViewModels;
using FoodZone.Web.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using FoodZone.Services.Services;
using FoodZone.Models.Security;
using System.Threading.Tasks;

namespace FoodZone.Web.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationServices _reservationServices;
        private readonly IReservationDetailsServices _reservationDetailsServices;
        private readonly ICheckoutServices _checkoutServices;
        private readonly IMenuServices _menuServices;
        private readonly ITableServices _tableServices;
        private readonly IUserVoucherServices _userVoucherServices;
        private readonly IVoucherServices _voucherServices;

        public ReservationController(IReservationServices reservationServices,
            IReservationDetailsServices reservationDetailsServices,
            ICheckoutServices checkoutServices,
            IMenuServices menuServices,
            ITableServices tableServices,
            IUserVoucherServices userVoucherServices,
            IVoucherServices voucherServices)
        {
            _reservationServices = reservationServices;
            _reservationDetailsServices = reservationDetailsServices;
            _checkoutServices = checkoutServices;
            _menuServices = menuServices;
            _tableServices = tableServices;
            _userVoucherServices = userVoucherServices;
            _voucherServices = voucherServices;
        }

        private UserManager _userManager;
        public UserManager UserManager
        {
            get => _userManager ?? HttpContext.GetOwinContext().GetUserManager<UserManager>();
            private set => _userManager = value;
        }

        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();
                var user = UserManager.FindById(userId);
                var reservationViewModel = new ReservationViewModel()
                {
                    CusName = user.FullName,
                    PhoneNumber = user.PhoneNumber
                };
                ViewBag.MenuId = new SelectList(_menuServices.GetAll().Where(x => x.Name != "Thực Đơn Đặc Biệt"), "Id", "Name");
                ViewBag.CodeId = new SelectList(GetAllAvailableVoucherForUser(), "Id", "Code");
                return View(reservationViewModel);
            }
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(ReservationViewModel reservationViewModel)
        {
            var menu = _menuServices.GetById(reservationViewModel.MenuId);
            var voucher = _voucherServices.GetById(reservationViewModel.CodeId);
            string code = "";

            if(voucher != null)
            {
                code = voucher.Code;
            }
            decimal menuPrice = menu.Price;
            string str = "";
            if (!string.IsNullOrEmpty(reservationViewModel.TableFloorCapacity))
            {
                str = reservationViewModel.TableFloorCapacity;
                string[] floorCapacity = str.Split('-');
                decimal tableCapacity = Convert.ToDecimal(floorCapacity[0]);
                int floor = Convert.ToInt32(floorCapacity[1]);
                var tables = _tableServices.GetAll().Where(x => x.Floor == floor && x.Capacity == tableCapacity && x.Status == 0).ToList();

                if (!IsEnoughTable(tables, reservationViewModel.Capacity))
                {
                    ViewBag.MenuId = new SelectList(_menuServices.GetAll().Where(x => x.Name != "Thực Đơn Đặc Biệt"), "Id", "Name");
                    return View(reservationViewModel);
                }
                else
                {
                    tables = tables.Take(reservationViewModel.Capacity).ToList();
                }

                if (ModelState.IsValid)
                {
                    if (reservationViewModel.CodeId > 0)
                    {
                        ApplyVoucher(voucher.Code);
                    }
                    var reservationDetails = new List<ReservationDetail>();
                    foreach (var item in tables)
                    {
                        var reservationDetail = new ReservationDetail
                        {
                            TableId = item.Id,
                            MenuId = menu.Id,
                            MenuPrice = menu.Price
                        };
                        reservationDetails.Add(reservationDetail);
                        UpdateTableStatus(item.Id, 1);
                    }

                    var reservation = new Reservation
                    {
                        Capacity = reservationViewModel.Capacity,
                        Name = reservationViewModel.CusName,
                        PhoneNumber = reservationViewModel.PhoneNumber,
                        ReservationDate = DateTime.Parse(reservationViewModel.ReservationDate)
                                                  .AddHours(reservationViewModel.Hours)
                                                  .AddMinutes(reservationViewModel.Minute),
                        Note = reservationViewModel.Note,
                        Code = code,
                        Status = 0,
                        UserId = User.Identity.GetUserId()
                    };
                    TableHub.BroadcastData();
                    await _checkoutServices.CheckoutAsync(reservation, reservationDetails);
                    return RedirectToAction("ReservationSuccess", "Reservation");
                }
                ViewBag.CodeId = new SelectList(GetAllAvailableVoucherForUser(), "Id", "Code");
            }
            ViewBag.MenuId = new SelectList(_menuServices.GetAll().Where(x => x.Name != "Thực Đơn Đặc Biệt"), "Id", "Name");
            ViewBag.CodeId = new SelectList(GetAllAvailableVoucherForUser(), "Id", "Code");
            return View(reservationViewModel);
        }

        public ActionResult ReservationSuccess()
        {
            var userId = User.Identity.GetUserId();
            var user = UserManager.FindById(userId);
            ViewBag.ReservationSuccess = "Cảm ơn " + user.FullName + " đã đặt bàn, mong bạn sẽ đến đúng giờ nhé!";
            return View();
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var reservation = _reservationServices.GetById(id);
            var detail = new ReservationDetailViewModel()
            {
                Id = id,
                CancelReason = reservation.CancelReason,
                Code = reservation.Code,
                CusName = reservation.Name,
                Note = reservation.Note,
                PhoneNumber = reservation.PhoneNumber ,
                ReservationDate = reservation.ReservationDate,
                Status = reservation.Status 
            };
            ViewBag.Detail = reservation.ReservationDate.ToShortDateString();
            return View(detail);
        }

        public ActionResult GetReservationDetails(int reservationId)
        {
            var list = _reservationDetailsServices.GetReservationDetailsByReservation(reservationId);
            return PartialView("_GetReservationDetails", list);
        }

        public int GetTableNumber(int tableId)
        {
            var table = _tableServices.GetById(tableId);
            return table.NumberTable;
        }

        public string GetMenuName(int menuId)
        {
            var menu = _menuServices.GetById(menuId);
            return menu.Name;
        }

        private void ChangeTableStatus(Reservation reservation)
        {
            var details = _reservationDetailsServices.GetReservationDetailsByReservation(reservation.Id);

            foreach (var item in details)
            {
                var table = _tableServices.GetById(item.TableId);
                if (reservation.Status == 0)
                {
                    table.Status = 1;
                }
                else if (reservation.Status == 2 || reservation.Status == -1)
                {
                    table.Status = 0;
                }
                _tableServices.Update(table);
            }
        }

        [HttpPost]
        public ActionResult Details(ReservationDetailViewModel model)
        {
            if (ModelState.IsValid)
            {
                var reservation = _reservationServices.GetById(model.Id);

                reservation.Status = -1;
                reservation.CancelReason = model.CancelReason;
                if (!string.IsNullOrEmpty(reservation.Code))
                {
                    var voucher = _voucherServices.GetByCode(reservation.Code);
                    var userVoucher = _userVoucherServices.GetAll().Where(x => x.VoucherId == voucher.Id && x.UserId == User.Identity.GetUserId()).FirstOrDefault();
                    if(userVoucher != null)
                    {
                        _userVoucherServices.Delete(userVoucher);
                    }
                }

                ChangeTableStatus(reservation);
                var result = _reservationServices.Update(reservation);
                if (result)
                {
                    TempData["Message"] = "Hủy đặt bàn thành công!";
                }
                else
                {
                    TempData["Message"] = "Hủy đặt bàn thất bại!";
                }
                return RedirectToAction("Index", "Manage");
            }
            return View(model);
        }

        public ActionResult History()
        {
            var reservations = _reservationServices.GetAll().Where(x => x.UserId == User.Identity.GetUserId()).ToList();
            return PartialView("_Reservations", reservations);
        }

        private bool IsEnoughTable(List<Table> tables, int tableNeed)
        {
            if (tableNeed <= 0 || tables.Count < tableNeed)
            {
                return false;
            }
            return true;
        }

        private void UpdateTableStatus(int tableId, int status)
        {
            var table = _tableServices.GetById(tableId);
            table.Status = status;
            _tableServices.Update(table);
            TableHub.BroadcastData();
        }

        private void ApplyVoucher(string code)
        {
            if (!string.IsNullOrEmpty(code))
            {
                var voucher = _voucherServices.GetByCode(code);
                var user = UserManager.FindById(User.Identity.GetUserId());

                var userApply = _userVoucherServices.GetAll().Where(x => x.VoucherId == voucher.Id && x.UserId == user.Id).FirstOrDefault();

                if (userApply == null && voucher.Status == 1)
                {
                    if (user.Level >= voucher.Level)
                    {
                        var userVoucher = new UserVoucher
                        {
                            UserId = user.Id,
                            VoucherId = voucher.Id
                        };

                        _userVoucherServices.Add(userVoucher);
                    }
                }
            }
        }

        public IEnumerable<Voucher> GetAllAvailableVoucherForUser()
        {
            var vouchers = _voucherServices.GetAll().Where(x => x.Status == 1);
            var availableVouchers = new List<Voucher>();
            var userVouchers = _userVoucherServices.GetAll();

            foreach (var item in vouchers)
            {
                if (userVouchers.Where(x => x.VoucherId == item.Id && x.UserId == User.Identity.GetUserId()).FirstOrDefault() == null)
                {
                    availableVouchers.Add(item);
                }
            }
            return availableVouchers.ToList();
        }
    }
}