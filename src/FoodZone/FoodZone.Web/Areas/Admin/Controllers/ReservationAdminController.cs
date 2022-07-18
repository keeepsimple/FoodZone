using FoodZone.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodZone.Web.Areas.Admin.Controllers
{
    public class ReservationAdminController:Controller
    {
        private readonly IReservationServices _reservationServices;

        public ReservationAdminController(IReservationServices reservationServices)
        {
            _reservationServices = reservationServices;
        }

        public ActionResult Index()
        {
            var reservations = _reservationServices.GetAll();
            return View(reservations);
        }
    }
}