﻿using FoodZone.Models.Common;
using FoodZone.Services.IServices;
using FoodZone.Services.Services;
using FoodZone.Web.Areas.Admin.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FoodZone.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Manager")]
    public class CategoryAdminController : Controller
    {
        private readonly ICategoryServices _categoryServices;
        private readonly IFoodServices _foodServices;

        public CategoryAdminController(ICategoryServices categoryServices, IFoodServices foodServices)
        {
            _categoryServices = categoryServices;
            _foodServices = foodServices;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var categories = await _categoryServices.GetAllAsync();

            return View(categories);
        }

        public ActionResult Create()
        {
            var categoryViewModel = new CategoryViewModel();
            categoryViewModel.Foods = _foodServices.GetAll().Select(t => new SelectListItem { Value = t.Id.ToString(), Text = t.Name });
            
            return View(categoryViewModel);
        }

        [HttpPost]

        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Create(CategoryViewModel model, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid)
            {
                string fileName = "";

                if (uploadImage != null)
                {
                    fileName = Path.GetFileName(uploadImage.FileName);
                    string folderPath = Path.Combine(Server.MapPath("~/assets/images/category"), uploadImage.FileName);
                    uploadImage.SaveAs(folderPath);
                }

                model.Image = fileName;

                var category = new Category
                {
                    Name = model.Name,
                    Image = model.Image
                };

                var result = await _categoryServices.AddAsync(category);

                if (result > 0)
                {
                    await GetSelectedFoodsFromIds(model.SelectedFoodIds, category);
                    TempData["Message"] = "Tạo thành công.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Message"] = "Tạo thất bại. Thử lại sau nhé!";
                }
            }

            model.Foods = _foodServices.GetAll().Select(t => new SelectListItem { Value = t.Id.ToString(), Text = t.Name });

            return View(model);
        }

        private async Task GetSelectedFoodsFromIds(IEnumerable<int> selectedFoodIds, Category category)
        {
            List<Food> foods = new List<Food>();

            foreach (var item in selectedFoodIds)
            {
                var food = await _foodServices.GetByIdAsync(item);
                foods.Add(food);
            }

            category.Foods = foods;
            _categoryServices.Update(category);
        }

        private async Task UpdateSelectedFoodFromIds(IEnumerable<int> selectedFoodIds, Category category)
        {
            List<Food> foods = new List<Food>();

            category.Foods = foods;
            _categoryServices.Update(category);

            foreach (var item in selectedFoodIds)
            {
                var food = await _foodServices.GetByIdAsync(item);
                foods.Add(food);
            }

            category.Foods = foods;
            _categoryServices.Update(category);
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var category = await _categoryServices.GetByIdAsync((int)id);

            if (category == null)
            {
                return HttpNotFound();
            }

            var categoryViewModel = new CategoryViewModel
            {
                Name = category.Name,
                Image = category.Image,
                SelectedFoodIds = _categoryServices.GetFoodIdByCategory(category.Id)
            };

            categoryViewModel.Foods = _foodServices.GetAll().Select(t => new SelectListItem { Value = t.Id.ToString(), Text = t.Name });
            ViewBag.FoodList = _foodServices.GetAll();

            return View(categoryViewModel);
        }

        [HttpPost]

        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Edit(CategoryViewModel model, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid)
            {
                string fileName = "";
                if (uploadImage != null && uploadImage.ContentLength > 0)
                {
                    fileName = Path.GetFileName(uploadImage.FileName);
                    string folderPath = Path.Combine(Server.MapPath("~/assets/images/category"), uploadImage.FileName);
                    uploadImage.SaveAs(folderPath);
                }

                if (!string.IsNullOrEmpty(fileName))
                {
                    model.Image = fileName;
                }

                var category = await _categoryServices.GetByIdAsync(model.Id);

                if (category == null)
                {
                    return HttpNotFound();
                }

                category.Name = model.Name;
                category.Image = model.Image;

                var result = await _categoryServices.UpdateAsync(category);

                await UpdateSelectedFoodFromIds(model.SelectedFoodIds, category);

                if (result)
                {
                    TempData["Message"] = "Cập nhật thành công.";
                }
                else
                {
                    TempData["Message"] = "Cập nhật thất bại.";
                }

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _categoryServices.DeleteAsync(id);

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