using FoodZone.Models.Common;
using FoodZone.Services.IServices;
using FoodZone.Web.Areas.Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FoodZone.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Manager")]
    public class MenuAdminController : Controller
    {
        private readonly IMenuServices _menuServices;
        private readonly IMenuFoodServices _menuFoodServices;
        private readonly IFoodServices _foodServices;

        public MenuAdminController(IMenuServices menuServices, IMenuFoodServices menuFoodServices, IFoodServices foodServices)
        {
            _menuServices = menuServices;
            _menuFoodServices = menuFoodServices;
            _foodServices = foodServices;
        }

        public ActionResult Index()
        {
            var menu = _menuServices.GetAll();
            return View(menu);
        }

        public ActionResult Create()
        {
            var menuViewModel = new MenuViewModel();
            menuViewModel.Foods = _foodServices.GetAll().Select(t => new SelectListItem { Value = t.Id.ToString(), Text = t.Name });
            return View(menuViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MenuViewModel model)
        {
            if (ModelState.IsValid)
            {
                var menu = new Menu
                {
                    Name = model.Name,
                    Description = model.Description
                };

                var result = await _menuServices.AddAsync(menu);
                if (result > 0)
                {
                    await GetSelectedMenuFoodFromIds(model.SelectedFoodIds, menu);
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

        private async Task GetSelectedMenuFoodFromIds(IEnumerable<int> selectedFoodIds, Menu menu)
        {
            foreach (var item in selectedFoodIds)
            {
                var menuFood = new MenuFood
                {
                    MenuId = menu.Id,
                    FoodId = item
                };
                await _menuFoodServices.AddAsync(menuFood);
            }
        }

        private async Task UpdateSelectedFoodFromIds(IEnumerable<int> selectedFoodIds, Menu menu)
        {
            _menuFoodServices.RemoveMenuFoodsByMenu(menu.Id);
            foreach (var item in selectedFoodIds)
            {
                var menuFood = new MenuFood
                {
                    MenuId = menu.Id,
                    FoodId = item
                };
                await _menuFoodServices.AddAsync(menuFood);
            }
        }

        // GET: MenuManagementController/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var menu = await _menuServices.GetByIdAsync((int)id);
            if (menu == null)
            {
                return HttpNotFound();
            }

            var menuViewModel = new MenuViewModel
            {
                Name = menu.Name,
                Description = menu.Description,
                SelectedFoodIds = _menuFoodServices.GetFoodIdByMenu(menu.Id)
            };
            menuViewModel.Foods = _foodServices.GetAll().Select(t => new SelectListItem { Value = t.Id.ToString(), Text = t.Name });
            ViewBag.FoodList = _foodServices.GetAll();

            return View(menuViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(MenuViewModel menuViewModel)
        {
            if (ModelState.IsValid)
            {
                var menu = await _menuServices.GetByIdAsync(menuViewModel.Id);
                if (menu == null)
                {
                    return HttpNotFound();
                }

                menu.Name = menuViewModel.Name;
                menu.Description = menuViewModel.Description;

                var result = await _menuServices.UpdateAsync(menu);

                await UpdateSelectedFoodFromIds(menuViewModel.SelectedFoodIds, menu);

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
            return View(menuViewModel);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _menuServices.DeleteAsync(id);
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