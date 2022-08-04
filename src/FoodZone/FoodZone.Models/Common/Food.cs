using FoodZone.Models.BaseEntities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodZone.Models.Common
{
    public class Food:BaseEntity
    {
        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [StringLength(255, ErrorMessage = "Tên phải từ {2} đến {1} ký tự", MinimumLength = 2)]
        [Display(Name = "Tên")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [Range(0, int.MaxValue, ErrorMessage = "Vui lòng nhập giá trị lớn hơn {1}")]
        [Display(Name = "Giá")]
        public decimal Price { get; set; }

        public int? CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
