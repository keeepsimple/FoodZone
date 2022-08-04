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
            var menu = _menuServices.GetById(reservationViewModel.MenuId);
            decimal menuPrice = menu.Price;
            string str = reservationViewModel.TableFloorCapacity;
            string[] floorCapacity = str.Split('-');
            decimal capacity = Convert.ToDecimal(floorCapacity[0]);
            int floor = Convert.ToInt32(floorCapacity[1]);
            decimal tableNeed = Math.Ceiling((reservationViewModel.Adult + reservationViewModel.Child)/capacity);
            var tables = _tableServices.GetAll().Where(x => x.Floor == floor && x.Capacity == capacity && x.Status == 0).Take((int)tableNeed).ToList();
            if (ModelState.IsValid)
            {
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
                    Adult = reservationViewModel.Adult,
                    Child = reservationViewModel.Child,
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