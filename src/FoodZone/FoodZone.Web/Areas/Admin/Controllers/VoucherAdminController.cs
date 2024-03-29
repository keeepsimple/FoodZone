﻿using FoodZone.Services.IServices;
using FoodZone.Web.Areas.Admin.ViewModels;
using PagedList;
using System.Linq;
using System.Threading.Tasks;
using FoodZone.Models.Common;
using System.Web.Mvc;
using System.Net;
using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using FoodZone.Services.Services;

namespace FoodZone.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Manager")]
    public class VoucherAdminController : Controller
    {
        private readonly IVoucherServices _voucherServices;

        public VoucherAdminController(IVoucherServices voucherServices)
        {
            _voucherServices = voucherServices;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var vouchers = await _voucherServices.GetAllAsync();
            return View(vouchers);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public async Task<ActionResult> Create(VoucherViewModel model, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid)
            {
                string fileName = "";

                if (uploadImage != null)
                {
                    fileName = Path.GetFileName(uploadImage.FileName);
                    string folderPath = Path.Combine(Server.MapPath("~/assets/images"), uploadImage.FileName);
                    uploadImage.SaveAs(folderPath);
                }
                var status = 0;
                model.Image = fileName;
                var checkExpired = CompareDate(DateTime.Now, model.ExpiredDate);
                if (checkExpired <= 0)
                {
                    status = 1;
                }
                else
                {
                    status = 0;
                }
                var voucher = new Voucher
                {
                    Title = model.Title,
                    Code = model.Code,
                    Content = model.Content,
                    Image = model.Image,
                    ShortDescription = model.ShortDescription,
                    ExpiredDate = model.ExpiredDate,
                    Level = model.Level,
                    Status = status
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
                ShortDescription= voucher.ShortDescription,
                Image = voucher.Image,
                ExpiredDate = voucher.ExpiredDate,
                Status = voucher.Status,
                Code = voucher.Code
            };

            return View(voucherViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public async Task<ActionResult> Edit(VoucherViewModel model, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid)
            {
                string fileName = "";

                if (uploadImage != null && uploadImage.ContentLength > 0)
                {
                    fileName = Path.GetFileName(uploadImage.FileName);
                    string folderPath = Path.Combine(Server.MapPath("~/assets/images"), uploadImage.FileName);
                    uploadImage.SaveAs(folderPath);
                }

                if (!string.IsNullOrEmpty(fileName))
                {
                    model.Image = fileName;
                }

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
                voucher.Image = model.Image;
                voucher.ShortDescription = model.ShortDescription;
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