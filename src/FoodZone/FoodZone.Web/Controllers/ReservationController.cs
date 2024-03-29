﻿using FoodZone.Models.Common;
using FoodZone.Services.IServices;
using FoodZone.Web.Helpers;
using FoodZone.Web.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly IVoucherServices _voucherServices;
        private readonly IUserVoucherServices _userVoucherServices;

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

            var listReservation = _reservationServices.GetReservationByUser(User.Identity.GetUserId());
            if (listReservation.Count() > 0)
            {
                return RedirectToAction("History");
            }
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

            if (voucher != null)
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
                        await UpdateTableStatus(item.Id, 1);
                    }
                    string[] time = reservationViewModel.Time.Split(':');
                    var hour = int.Parse(time[0]);
                    var min = int.Parse(time[1]);
                    var reservation = new Reservation
                    {
                        Capacity = reservationViewModel.Capacity,
                        Name = reservationViewModel.CusName,
                        PhoneNumber = reservationViewModel.PhoneNumber,
                        ReservationDate = DateTime.Parse(reservationViewModel.ReservationDate)
                                                  .AddHours(hour)
                                                  .AddMinutes(min),
                        Note = reservationViewModel.Note,
                        Code = code,
                        Status = 0,
                        UserId = User.Identity.GetUserId()
                    };
                    await _checkoutServices.CheckoutAsync(reservation, reservationDetails);
                    TableHub.BroadcastData();
                    return RedirectToAction("History", "Reservation");
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
                PhoneNumber = reservation.PhoneNumber,
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

        private async Task ChangeTableStatus(Reservation reservation)
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
                await _tableServices.UpdateAsync(table);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Details(ReservationDetailViewModel model)
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
                    if (userVoucher != null)
                    {
                        _userVoucherServices.Delete(userVoucher);
                    }
                }

                await ChangeTableStatus(reservation);
                var result = await _reservationServices.UpdateAsync(reservation);
                TableHub.BroadcastData();
                if (result)
                {
                    TempData["Message"] = "Hủy đặt bàn thành công!";
                }
                else
                {
                    TempData["Message"] = "Hủy đặt bàn thất bại!";
                }
                return RedirectToAction("History");
            }
            return View(model);
        }

        public ActionResult History()
        {
            var reservations = _reservationServices.GetAll().Where(x => x.UserId == User.Identity.GetUserId()).ToList();
            return View(reservations);
        }

        private bool IsEnoughTable(List<Table> tables, int tableNeed)
        {
            if (tableNeed <= 0 || tables.Count < tableNeed)
            {
                return false;
            }
            return true;
        }

        private async Task UpdateTableStatus(int tableId, int status)
        {
            var table = _tableServices.GetById(tableId);
            table.Status = status;
            await _tableServices.UpdateAsync(table);
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
            var user = UserManager.FindById(User.Identity.GetUserId());
            var vouchers = _voucherServices.GetAll().Where(x => x.Status == 1 && user.Level >= x.Level);
            var availableVouchers = new List<Voucher>();
            var userVouchers = _userVoucherServices.GetAll();

            foreach (var item in vouchers)
            {
                if (userVouchers.Where(x => x.VoucherId == item.Id && x.UserId == user.Id).FirstOrDefault() == null)
                {
                    availableVouchers.Add(item);
                }
            }
            return availableVouchers.ToList();
        }
    }
}