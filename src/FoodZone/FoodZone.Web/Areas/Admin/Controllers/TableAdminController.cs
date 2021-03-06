using FoodZone.Models.Common;
using FoodZone.Services.IServices;
using FoodZone.Services.Services;
using FoodZone.Web.Areas.Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FoodZone.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Manager")]
    public class TableAdminController : Controller
    {
        private readonly ITableServices _tableServices;

        public TableAdminController(ITableServices tableServices)
        {
            _tableServices = tableServices;
        }

        public ActionResult Index()
{
            var table = _tableServices.GetAll();
            return View(table);
        }

        public ActionResult Create()
        {
            var tableViewModel = new TableViewModel();
            return View(tableViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TableViewModel model)
        {
            if (ModelState.IsValid)
            {
                var table = new Table
                {
                    Capacity = model.Capacity,
                    Floor = model.Floor,
                    NumberTable = model.NumberTable,
                    Status = 0
                };

                var result = await _tableServices.AddAsync(table);
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

            var table = await _tableServices.GetByIdAsync((int)id);
            if (table == null)
            {
                return HttpNotFound();
            }

            var tableViewModel = new TableViewModel
            {
                Capacity = table.Capacity,
                Floor = table.Floor,
                NumberTable = table.NumberTable,
                Status = table.Status
            };

            return View(tableViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(TableViewModel model)
        {
            if (ModelState.IsValid)
            {
                var table = await _tableServices.GetByIdAsync(model.Id);
                if (table == null)
                {
                    return HttpNotFound();
                }

                table.Capacity = model.Capacity;
                table.Floor = model.Floor;
                table.NumberTable = model.NumberTable;

                var result = await _tableServices.UpdateAsync(table);
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
            var result = await _tableServices.DeleteAsync(id);
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