using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace FoodZone.Web.Areas.Admin.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Không để trống")]
        [StringLength(255, ErrorMessage = "Tên phải từ {2} đến {1} ký tự", MinimumLength = 3)]
        public string Name { get; set; }

        public IEnumerable<int> SelectedFoodIds { get; set; }

        public IEnumerable<SelectListItem> Foods { get; set; }
    }
}