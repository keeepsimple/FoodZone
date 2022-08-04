using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace FoodZone.Web.Areas.Admin.ViewModels
{
    public class FoodViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [StringLength(255, ErrorMessage = "Tên phải từ {2} đến {1} ký tự", MinimumLength = 3)]
        [Display(Name = "Tên")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [Range(0, int.MaxValue, ErrorMessage = "Vui lòng nhập giá trị lớn hơn {1}")]
        [Display(Name = "Giá")]
        public decimal Price { get; set; }
    }
}