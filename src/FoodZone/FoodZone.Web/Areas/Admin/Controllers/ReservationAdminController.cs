using FoodZone.Models.Common;
using FoodZone.Services.IServices;
using FoodZone.Web.Areas.Admin.ViewModels;
using Microsoft.AspNet.Identity.Owin;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FoodZone.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Manager,Staff")]
    public class ReservationAdminController : Controller
    {
        private readonly IReservationServices _reservationServices;
        private readonly IReservationDetailsServices _reservationDetailServices;
        private readonly ITableServices _tableServices;
        private readonly IMenuServices _menuServices;
        private readonly IFoodServices _foodServices;

        private UserManager _userManager;
        public UserManager UserManager
        {
            get => _userManager ?? HttpContext.GetOwinContext().GetUserManager<UserManager>();
            private set => _userManager = value;
        }

        public ReservationAdminController(IReservationServices reservationServices,
            IReservationDetailsServices reservationDetailServices,
            ITableServices tableServices,
            IMenuServices menuServices,
            IFoodServices foodServices)
        {
            _reservationServices = reservationServices;
            _reservationDetailServices = reservationDetailServices;
            _tableServices = tableServices;
            _menuServices = menuServices;
            _foodServices = foodServices;
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

            var reservation = _reservationServices.GetById((int)id);

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
                if (reservation == null)
                {
                    return HttpNotFound();
                }

                if (reservation.Status == 0)
                {
                    reservation.Status = 1;
                }
                else if (reservation.Status == 1)
                {
                    reservation.Status = 2;

                }
                else if (reservation.Status == 2)
                {
                    reservation.Status = 3;
                }

                if (!string.IsNullOrEmpty(model.CancelReason))
                {
                    reservation.Status = 4;
                }

                ChangeTableStatus(reservation);

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

        private void ChangeTableStatus(Reservation reservation)
        {
            var details = _reservationDetailServices.GetReservationDetailsByReservation(reservation.Id);

            foreach (var item in details)
            {
                var table = _tableServices.GetById(item.TableId);
                if (reservation.Status == 2)
                {
                    table.Status = 2;
                }
                else if (reservation.Status == 3 || reservation.Status == 4)
                {
                    table.Status = 0;
                }
                _tableServices.Update(table);
            }
        }

        public ActionResult GetReservationDetails(int reservationId)
        {
            var list = _reservationDetailServices.GetReservationDetailsByReservation(reservationId);
            return PartialView(list);
        }

        public string GetFoodName(int foodId)
        {
            var food = _foodServices.GetById(foodId);
            return food.Name;
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
    }
}