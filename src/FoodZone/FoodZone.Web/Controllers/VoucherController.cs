using FoodZone.Services.IServices;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FoodZone.Web.Controllers
{
    public class VoucherController:Controller
    {
        private readonly IVoucherServices _voucherServices;

        public VoucherController(IVoucherServices voucherServices)
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
            if (!string.IsNullOrEmpty(searchString))
            {
                vouchers = vouchers.Where(s => s.Title.Contains(searchString)).ToList();
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(vouchers.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Details(int voucherId)
        {
            var voucher = _voucherServices.GetById(voucherId);
            if (voucher == null)
            {
                return HttpNotFound();
            }
            ViewBag.Voucher = voucher.Title;
            return View(voucher);
        }
    }
}