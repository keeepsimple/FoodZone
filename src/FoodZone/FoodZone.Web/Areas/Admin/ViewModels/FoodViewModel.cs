using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace FoodZone.Web.Areas.Admin.ViewModels
{
    public class FoodViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Không để trống")]
        [StringLength(255, ErrorMessage = "Tên phải từ {2} đến {1} ký tự", MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Không để trống")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Không để trống")]
        [StringLength(500, ErrorMessage = "Mô tả không lớn hơn 500 ký tự")]
        public string Description { get; set; }
    }
}