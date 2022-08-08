using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodZone.Web.ViewModels
{
    public class TableViewModel
    {
        public int Floor { get; set; }

        public int Capacity { get; set; }

        public int Count { get; set; }
        public int Quantity { get; set; }
    }
}