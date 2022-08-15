using FoodZone.Models.Common;
using FoodZone.Services.IServices;
using FoodZone.Services.Services;
using FoodZone.Web.Areas.Admin.ViewModels;
using FoodZone.Web.Helpers;
using PagedList;
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

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var tables = await _tableServices.GetAllAsync();
            return View(tables);
        }

        public ActionResult AutoCreateTable()
        {
            var model = new AutoCreateTableModel();
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> AutoCreateTable(AutoCreateTableModel model)
        {
            int numberTable = 1;
            if (ModelState.IsValid)
            {
                var tables = await _tableServices.GetAllAsync();
                if (tables.Count() > 0)
                {
                    numberTable = tables.OrderByDescending(x => x.NumberTable).FirstOrDefault().NumberTable;
                }

                var capacities = model.Capacities.Split(',');

                for (int i = 0; i < model.NumberOfTable; i++)
                {
                    foreach (var item in capacities)
                    {
                        var table = new Table
                        {
                            Capacity = Convert.ToInt32(item),
                            Floor = model.Floor,
                            NumberTable = numberTable++,
                            Status = 0
                        };
                        await _tableServices.AddAsync(table);
                    }
                    TableHub.BroadcastData();
                }

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Create()
        {
            var tableViewModel = new TableViewModel();
            var lastestTableNumber = _tableServices.GetAll().Select(x => x.NumberTable).FirstOrDefault();
            tableViewModel.NumberTable = lastestTableNumber + 1;
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
                TableHub.BroadcastData();
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
                    TableHub.BroadcastData();
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
                TableHub.BroadcastData();
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