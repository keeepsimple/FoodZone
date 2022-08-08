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
                return View(reservationViewModel);
            }
            ViewBag.MenuId = new SelectList(_menuServices.GetAll().Where(x => x.Name != "Thực Đơn Đặc Biệt"), "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Index(ReservationViewModel reservationViewModel)
        {
            var menu = _menuServices.GetById(reservationViewModel.MenuId);
            decimal menuPrice = menu.Price;

            string str = reservationViewModel.TableFloorCapacity;
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
                ApplyVoucher(reservationViewModel.Code, tables.Count);
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
                    Status = 0,
                    UserId = User.Identity.GetUserId()
                };

                _checkoutServices.Checkout(reservation, reservationDetails);
                return RedirectToAction("ReservationSuccess", "Reservation");
            }
            ViewBag.MenuId = new SelectList(_menuServices.GetAll().Where(x => x.Name != "Thực Đơn Đặc Biệt"), "Id", "Name");
            return View(reservationViewModel);
        }

        public ActionResult ReservationSuccess()
        {
            var userId = User.Identity.GetUserId();
            var user = UserManager.FindById(userId);
            ViewBag.ReservationSuccess = "Cảm ơn " + user.FullName + " đã đặt bàn, mong bạn sẽ đến đúng giờ nhé!";
            return View();
        }

        private bool IsEnoughTable(List<Table> tables, int tableNeed)
        {
            if (tableNeed <= 0 || (tables.Count <= tableNeed) && tableNeed > 0)
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

        private void ApplyVoucher(string code, int point)
        {
            if (!string.IsNullOrEmpty(code))
            {
                var voucher = _voucherServices.GetByCode(code);
                var user = UserManager.FindById(User.Identity.GetUserId());

                var userApply = _userVoucherServices.GetAll().Where(x => x.VoucherId == voucher.Id && x.UserId == user.Id).FirstOrDefault();

                if(userApply != null && voucher.Status == 1)
                {
                    if (user.Level >= voucher.Level)
                    {
                        var userVoucher = new UserVoucher
                        {
                            UserId = User.Identity.GetUserId(),
                            VoucherId = voucher.Id
                        };

                        _userVoucherServices.Add(userVoucher);
                        
                    }
                }
                user.Level += point;
                UserManager.Update(user);
            }
        }
    }
}