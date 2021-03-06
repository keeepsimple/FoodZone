using FoodZone.Models.Common;
using FoodZone.Services.IServices;
using FoodZone.Web.ViewModels;
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

        public ReservationController(IReservationServices reservationServices, 
            IReservationDetailsServices reservationDetailsServices,
            ICheckoutServices checkoutServices,
            IMenuServices menuServices,
            ITableServices tableServices)
        {
            _reservationServices = reservationServices;
            _reservationDetailsServices = reservationDetailsServices;
            _checkoutServices = checkoutServices;
            _menuServices = menuServices;
            _tableServices = tableServices;
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
            ViewBag.MenuId = new SelectList(_menuServices.GetAll().Where(x=>x.Name != "Thực Đơn Đặc Biệt"), "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Index(ReservationViewModel reservationViewModel)
        {
            var tables = Session["table"];
            var listTable = (List<Table>)tables;

            if (listTable.Count == 0)
            {
                return View("Index", "Reservation");
            }

            var menu = _menuServices.GetById(reservationViewModel.MenuId);
            decimal menuPrice = menu.Price;

            if (ModelState.IsValid)
            {
                var reservationDetails = new List<ReservationDetail>();
                foreach (var item in listTable)
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
                    Adult = reservationViewModel.Adult,
                    Child = reservationViewModel.Child,
                    Name = reservationViewModel.CusName,
                    PhoneNumber = reservationViewModel.PhoneNumber,
                    ReservationDate = reservationViewModel.ReservationDate.AddHours(reservationViewModel.Hours).AddMinutes(reservationViewModel.Minute),
                    Note = reservationViewModel.Note,
                    Status = 0,
                    TotalPrice = menuPrice*reservationViewModel.Adult + menuPrice*reservationViewModel.Child - (reservationViewModel.Child*50000),
                    UserId = User.Identity.GetUserId()
                };

                _checkoutServices.Checkout(reservation, reservationDetails);
                listTable.Clear();
                return RedirectToAction("ReservationSuccess", "Reservation");
            }
            ViewBag.MenuId = new SelectList(_menuServices.GetAll().Where(x => x.Name != "Thực Đơn Đặc Biệt"), "Id", "Name");
            return View(reservationViewModel);
        }

        public ActionResult ReservationSuccess()
        {
            var userId = User.Identity.GetUserId();
            var user = UserManager.FindById(userId);
            ViewBag.ReservationSuccess = "Cảm ơn "+ user.FullName + " đã đặt bàn, mong bạn sẽ đến đúng giờ nhé!";
            return View();
        }

        private void UpdateTableStatus(int tableId, int status)
        {
            var table = _tableServices.GetById(tableId);
            table.Status = status;
            _tableServices.Update(table);
        }
    }
}