using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace FoodZone.Web.Areas.Admin.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [StringLength(255, ErrorMessage = "Tên phải từ {2} đến {1} ký tự", MinimumLength = 3)]
        [Display(Name = "Tên")]
        public string Name { get; set; }

        [Display(Name = "Ảnh")]
        public string Image { get; set; }

        public IEnumerable<int> SelectedFoodIds { get; set; }

        public IEnumerable<SelectListItem> Foods { get; set; }
    }
}