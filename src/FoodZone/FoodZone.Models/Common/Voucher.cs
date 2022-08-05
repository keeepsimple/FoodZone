using FoodZone.Models.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodZone.Models.Common
{
    public class Voucher : BaseEntity
    {
        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [StringLength(255, ErrorMessage = "Tên phải từ {2} đến {1} ký tự", MinimumLength = 3)]
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [Display(Name = "Mã giảm giá")]
        public string Code { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [Display(Name = "Nội dung")]
        public string Content { get; set; }

        [Display(Name = "Ảnh")]
        public string Image { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [Display(Name = "Mô tả ngắn")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [Display(Name = "Ngày hết hiệu lực")]
        public DateTime ExpiredDate { get; set; }

        public int Status { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [Display(Name = "Cấp độ")]
        public int Level { get; set; }

        public virtual ICollection<UserVoucher> UserVouchers { get; set; }
    }
}
