using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodZone.Web.Areas.Admin.ViewModels
{
    public class MenuViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [StringLength(255, ErrorMessage = "Tên phải từ {2} đến {1} ký tự", MinimumLength = 3)]
        [Display(Name = "Tên")]
        public string Name { get; set; }

        [StringLength(500, ErrorMessage = "{0} không lớn hơn 500 ký tự")]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [Range(1, int.MaxValue, ErrorMessage = "Vui lòng nhập giá trị lớn hơn {1}")]
        [Display(Name = "Giá")]
        public decimal Price { get; set; }

        public IEnumerable<int> SelectedCategoryIds { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}