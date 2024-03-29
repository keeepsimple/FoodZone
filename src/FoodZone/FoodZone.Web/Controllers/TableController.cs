﻿using FoodZone.Data;
using FoodZone.Models.Common;
using FoodZone.Services.IServices;
using FoodZone.Web.Helpers;
using FoodZone.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodZone.Web.Controllers
{
    public class TableController : Controller
    {
        private readonly ITableServices _tableServices;

        public TableController(ITableServices tableServices)
        {
            _tableServices = tableServices;
        }

        public ActionResult GetAll()
        {
            var tables = new List<Table>();
            using (var ctx = new FoodZoneContext())
            {
                var command = ctx.Tables.SqlQuery("Select * from Tables Where IsDeleted = 0 and Status = 0");
                tables = command.ToList();
            }
            return PartialView("_ListTable", tables);
        }
    


        [HttpGet]
        public ActionResult GetTablesByCapacity(int floor)
        {
            var listTable = new List<TableViewModel>();
            var capacities = GetCapacity(floor);
            var tables = _tableServices.GetAll().Where(x => x.Floor == floor && x.Status == 0).ToList();
            foreach (var item in capacities)
            {
                var model = new TableViewModel
                {
                    Floor = floor,
                    Capacity = item,
                    Count = CountTableByCapacity(tables, floor, item),
                    Quantity = 0,
                };
                listTable.Add(model);
            }
            return PartialView("_TableArea", listTable);
        }

        public List<int> GetCapacity(int floor)
        {
            var tables = _tableServices.GetAll().Where(x => x.Floor == floor);
            return tables.Select(x => x.Capacity).Distinct().ToList();
        }


        public int CountTableByCapacity(IEnumerable<Table> tables, int floor, int capacity)
        {
            return tables.Where(x => x.Floor == floor && x.Capacity == capacity && x.Status == 0).Count();
        }
    }
}