using FoodZone.Data;
using FoodZone.Models.Common;
using FoodZone.Services.IServices;
using FoodZone.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodZone.Web.Controllers
{
    public class TableController:Controller
    {
        private readonly ITableServices _tableServices;

        public TableController(ITableServices tableServices)
        {
            _tableServices = tableServices;
        }

        public ActionResult GetAll()
        {
            var tables = _tableServices.GetAll();
            var cap2f1 = tables.Where(x => x.Capacity == 2 && x.Floor == 1 && x.Status == 0).Count();
            var cap6f1 = tables.Where(x => x.Capacity == 6 && x.Floor == 1 && x.Status == 0).Count();
            var cap8f1 = tables.Where(x => x.Capacity == 8 && x.Floor == 1 && x.Status == 0).Count();
            ViewBag.Cap2f1 = cap2f1;
            ViewBag.Cap6f1 = cap6f1;
            ViewBag.Cap8f1 = cap8f1;
            var cap2f2 = tables.Where(x => x.Capacity == 2 && x.Floor == 2 && x.Status == 0).Count();
            var cap6f2 = tables.Where(x => x.Capacity == 6 && x.Floor == 2 && x.Status == 0).Count();
            var cap8f2 = tables.Where(x => x.Capacity == 8 && x.Floor == 2 && x.Status == 0).Count();
            ViewBag.Cap2f2 = cap2f2;
            ViewBag.Cap6f2 = cap6f2;
            ViewBag.Cap8f2 = cap8f2;
            return PartialView("_ListTable", tables);
        }

        //public ActionResult GetByFloor(int floor)
        //{
        //    var tables = _tableServices.GetAll().Where(x => x.Floor == floor && x.Status == 0).ToList();

        //    return PartialView("_GetByFloor", tables);
        //}
    }
}