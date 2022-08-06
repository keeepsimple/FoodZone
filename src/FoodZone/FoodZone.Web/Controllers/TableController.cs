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
            return PartialView("_ListTable", tables);
        }

        public ActionResult GetTablesByCapacity(int floor)
        {
            var capacities = GetCapacity();
            var listTable = new List<TableViewModel>();
            var tables = _tableServices.GetAll().Where(x => x.Floor == floor && x.Status == 0).ToList();

            foreach (var item in capacities)
            {
                var model = new TableViewModel
                {
                    Floor = floor,
                    Capacity = item,
                    Count = CountTableByCapacity(tables, floor, item)
                };
                listTable.Add(model);
            }

            return PartialView("_TableArea",listTable);
        }

        public List<int> GetCapacity()
        {
            var tables = _tableServices.GetAll();
            return tables.Select(x => x.Capacity).Distinct().ToList();
        }

        public int CountTableByCapacity(IEnumerable<Table> tables,int floor, int capacity)
        {
            return tables.Where(x => x.Floor == floor && x.Capacity == capacity && x.Status == 0).Count();
        }
    }
}