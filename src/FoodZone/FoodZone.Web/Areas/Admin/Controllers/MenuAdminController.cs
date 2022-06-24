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

        public MenuAdminController(IMenuServices menuServices)
        {
            _menuServices = menuServices;
        }

        public ActionResult Index()
        {
            var menu = _menuServices.GetAll();
            return View(menu);
        }

        public ActionResult Create()
        {
            var menuViewModel = new MenuViewModel();
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
                    TempData["Message"] = "Tạo thành công.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Message"] = "Tạo thất bại. Thử lại sau nhé!";
                }
                return RedirectToAction("Index");
            }
            return View(model);
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
                Description = menu.Description
            };

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