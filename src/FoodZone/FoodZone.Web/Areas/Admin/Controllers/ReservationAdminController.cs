﻿using FoodZone.Models.Common;
using FoodZone.Services.IServices;
using FoodZone.Services.Services;
using FoodZone.Web.Areas.Admin.ViewModels;
using FoodZone.Web.Helpers;
using Microsoft.AspNet.Identity.Owin;
using PagedList;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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

        [HttpGet]
        public async Task<ActionResult> Index(string searchString, string currentFilter, int? page)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var news = await _reservationServices.GetAllAsync();
            if (!string.IsNullOrEmpty(searchString))
            {
                news = news.Where(s => s.PhoneNumber.Contains(searchString) 
                                            || s.Name.Contains(searchString)).ToList();
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(news.ToPagedList(pageNumber, pageSize));
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
                Capacity = reservation.Capacity,
                Id = reservation.Id,
                Name = reservation.Name,
                Note = reservation.Note,
                PhoneNumber = reservation.PhoneNumber,
                ReservationDate = reservation.ReservationDate,
                Status = reservation.Status,
                UserId = reservation.UserId,
                CancelReason = reservation.CancelReason,
                Code = reservation.Code
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ReservationViewModel model)
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

                if(reservation.Status == 3)
                {
                    var user = await UserManager.FindByIdAsync(reservation.UserId);
                    user.Level += reservation.Capacity;
                    await UserManager.UpdateAsync(user);
                }

                ChangeTableStatus(reservation);
                TableHub.BroadcastData();
                reservation.CancelReason = model.CancelReason;

                var result = await _reservationServices.UpdateAsync(reservation);
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