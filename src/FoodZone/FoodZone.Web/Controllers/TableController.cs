using FoodZone.Models.Common;
using FoodZone.Services.IServices;
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

        public ActionResult AddTable(int tableId)
        {
            var table = _tableServices.GetById(tableId);
            if (table == null)
            {
                return HttpNotFound();
            }

            List<Table> tables = (List<Table>)Session["table"];
            if(tables == null)
            {
                tables = new List<Table>();
            }

            foreach (var item in tables.ToList())
            {
                if(item.Id == tableId)
                {
                    tables.Remove(item);
                    Session["table"] = tables;
                }
            }

            tables.Add(table);
            Session["table"] = tables;
            return RedirectToAction("Index", "Reservation");
        }
    }
}