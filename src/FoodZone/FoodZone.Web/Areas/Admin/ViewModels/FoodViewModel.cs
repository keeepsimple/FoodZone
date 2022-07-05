using System.Collections.Generic;
using System.Web.Mvc;

namespace FoodZone.Web.Areas.Admin.ViewModels
{
    public class FoodViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }
    }
}