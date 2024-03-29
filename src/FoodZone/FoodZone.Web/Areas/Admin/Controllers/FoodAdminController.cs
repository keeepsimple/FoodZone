﻿using FoodZone.Models.Common;
using FoodZone.Services.IServices;
using FoodZone.Services.Services;
using FoodZone.Web.Areas.Admin.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FoodZone.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Manager")]
    public class FoodAdminController : Controller
    {
        private readonly IFoodServices _foodServices;

        public FoodAdminController(IFoodServices foodServices)
        {
            _foodServices = foodServices;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var foods = await _foodServices.GetAllAsync();
            return View(foods);
        }

        public ActionResult Create()
        {
            var foodViewModel = new FoodViewModel();
            return View(foodViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public async Task<ActionResult> Create(FoodViewModel model)
        {
            if (ModelState.IsValid)
            {
                var food = new Food
                {
                    Name = model.Name,
                    Price = model.Price
                };
                var result = await _foodServices.AddAsync(food);

                if (result > 0)
                {
                    TempData["Message"] = "Tạo thành công.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Message"] = "Tạo thất bại. Thử lại sau nhé!";
                }
            }

            return View(model);
        }

        public async Task<ActionResult> Edit(int? id)
        {
            var food = await _foodServices.GetByIdAsync((int)id);
            var foodViewModel = new FoodViewModel
            {
                Id = food.Id,
                Name = food.Name,
                Price = food.Price
            };

            return View(foodViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public async Task<ActionResult> Edit(FoodViewModel model)
        {
            if (ModelState.IsValid)
            {
                var food = await _foodServices.GetByIdAsync(model.Id);

                if (food == null)
                {
                    return HttpNotFound();
                }

                food.Name = model.Name;
                food.Price = model.Price;
                var result = await _foodServices.UpdateAsync(food);

                if (result)
                {
                    TempData["Message"] = "Sửa thành công.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Message"] = "Sửa thất bại. Thử lại sau nhé!";
                }
            }

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _foodServices.DeleteAsync(id);

            if (result)
            {
                TempData["Message"] = "Xóa thành công.";
            }
            else
            {
                TempData["Message"] = "Xóa thất bại!";
            }

            return RedirectToAction("Index");
        }
    }
}