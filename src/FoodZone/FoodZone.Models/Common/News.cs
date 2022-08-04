using FoodZone.Models.BaseEntities;
using FoodZone.Models.Security;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodZone.Models.Common
{
    public class News : BaseEntity
    {
        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [Display(Name = "Ảnh")]
        public string Image { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [Display(Name = "Nội dung")]
        public string Content { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [StringLength(500, ErrorMessage = "Mô tả không lớn hơn 500 ký tự")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [StringLength(255, ErrorMessage = "Tên phải từ {2} đến {1} ký tự", MinimumLength = 3)]
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }
    }
}
