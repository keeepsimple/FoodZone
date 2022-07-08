using FoodZone.Services.IServices;
using FoodZone.Web.Areas.Admin.ViewModels;
using PagedList;
using System.Linq;
using System.Threading.Tasks;
using FoodZone.Models.Common;
using System.Web.Mvc;
using System.Net;
using System;
using System.Collections.Generic;

namespace FoodZone.Web.Areas.Admin.Controllers
{
    public class VoucherAdminController : Controller
    {
        private readonly IVoucherServices _voucherServices;

        public VoucherAdminController(IVoucherServices voucherServices)
        {
            _voucherServices = voucherServices;
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

            var vouchers = await _voucherServices.GetAllAsync();
            AutoUpdateExpiredDate(vouchers);

            if (!string.IsNullOrEmpty(searchString))
            {
                vouchers = vouchers.Where(s => s.Title.Contains(searchString)).ToList();
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(vouchers.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Create()
        {
            var voucherViewModel = new VoucherViewModel();
            return View(voucherViewModel);
        }

        private int CompareDate(DateTime d1, DateTime d2)
        {
            return d1.CompareTo(d2);
        }

        private void AutoUpdateExpiredDate(IEnumerable<Voucher> vouchers)
        {
            foreach (var item in vouchers)
            {
                var checkExpired = CompareDate(DateTime.Now, item.ExpiredDate);
                if (checkExpired <= 0)
                {
                    item.Status = 1;
                }
                else
                {
                    item.Status = 0;
                }
                _voucherServices.Update(item);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public async Task<ActionResult> Create(VoucherViewModel model)
        {
            if (ModelState.IsValid)
            {
                var checkExpired = CompareDate(DateTime.Now, model.ExpiredDate);
                if(checkExpired <= 0)
                {
                    model.Status = 1;
                }
                else
                {
                    model.Status = 0;
                }
                var voucher = new Voucher
                {
                    Title = model.Title,
                    Code = model.Code,
                    Content = model.Content,
                    ExpiredDate = model.ExpiredDate,
                    Level = model.Level,
                    Status = model.Status
                };

                var result = await _voucherServices.AddAsync(voucher);
                if (result > 0)
                {
                    TempData["Message"] = "Tạo thành công.";
                }
                else
                {
                    TempData["Message"] = "Tạo thất bại. Thử lại sao nhé!";
                }
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var voucher = _voucherServices.GetById((int)id);

            if (voucher == null)
            {
                return HttpNotFound();
            }

            var voucherViewModel = new VoucherViewModel()
            {
                Id = voucher.Id,
                Title = voucher.Title,
                Content = voucher.Content,
                Level = voucher.Level,
                ExpiredDate = voucher.ExpiredDate,
                Status = voucher.Status,
                Code = voucher.Code
            };

            return View(voucherViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public async Task<ActionResult> Edit(VoucherViewModel model)
        {
            if (ModelState.IsValid)
            {

                var voucher = _voucherServices.GetById(model.Id);
                if (voucher == null)
                {
                    return HttpNotFound();
                }

                var checkExpired = CompareDate(DateTime.Now, model.ExpiredDate);
                if (checkExpired <= 0)
                {
                    voucher.Status = 1;
                }
                else
                {
                    voucher.Status = 0;
                }

                voucher.Title = model.Title;
                voucher.Level = model.Level;
                voucher.Content = model.Content;
                voucher.ExpiredDate = model.ExpiredDate;
                voucher.Code = model.Code;

                var result = await _voucherServices.UpdateAsync(voucher);

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
        public ActionResult Delete(int id)
        {
            var result = _voucherServices.Delete(id);
            if (result)
            {
                TempData["Message"] = "Xóa thành công.";
            }
            else
            {
                TempData["Message"] = "Xóa thất bại.";
            }
            return RedirectToAction("Index");
        }
    }
}