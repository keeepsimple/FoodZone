using System.Collections.Generic;
using System.Web.Mvc;

namespace FoodZone.Web.Areas.Admin.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<int> SelectedFoodIds { get; set; }

        public IEnumerable<SelectListItem> Foods { get; set; }
    }
}