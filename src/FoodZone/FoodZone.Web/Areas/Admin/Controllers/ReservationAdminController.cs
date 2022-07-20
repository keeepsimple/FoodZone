using FoodZone.Services.IServices;
using FoodZone.Services.Services;
using FoodZone.Web.Areas.Admin.ViewModels;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FoodZone.Web.Areas.Admin.Controllers
{
    public class ReservationAdminController:Controller
    {
        private readonly IReservationServices _reservationServices;
        private readonly IReservationDetailsServices _reservationDetailServices;

        private UserManager _userManager;
        public UserManager UserManager
        {
            get => _userManager ?? HttpContext.GetOwinContext().GetUserManager<UserManager>();
            private set => _userManager = value;
        }

        public ReservationAdminController(IReservationServices reservationServices, IReservationDetailsServices reservationDetailServices)
        {
            _reservationServices = reservationServices;
            _reservationDetailServices = reservationDetailServices;
        }

        public ActionResult Index()
        {
            var reservations = _reservationServices.GetAll();
            return View(reservations);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var reservation= _reservationServices.GetById((int)id);

            if (reservation == null)
            {
                return HttpNotFound();
            }

            var model = new ReservationViewModel
            {
                Adult = reservation.Adult,
                Child = reservation.Child,
                Id = reservation.Id,
                Name = reservation.Name,
                Note = reservation.Note,
                PhoneNumber = reservation.PhoneNumber,
                ReservationDate = reservation.ReservationDate,
                Status = reservation.Status,
                TotalPrice = reservation.TotalPrice,
                UserId = reservation.UserId,
                CancelReason = reservation.CancelReason
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ReservationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var reservation = _reservationServices.GetById(model.Id);
                if(reservation == null)
                {
                    return HttpNotFound();
                }

                if(model.Status == 0)
                {
                    reservation.Status = 1;
                }else if(model.Status == 1)
                {
                    reservation.Status=2;
                }

                reservation.CancelReason = model.CancelReason;

                var result = _reservationServices.Update(reservation);
                if (result)
                {
                    TempData["Message"] = "Cập nhật thành công.";

                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Message"] = "Cập nhật thất bại.";
                }
            }
            return View(model);
        }
    }
}