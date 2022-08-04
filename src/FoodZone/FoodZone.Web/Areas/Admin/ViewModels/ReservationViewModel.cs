using FoodZone.Models.Common;
using FoodZone.Models.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace FoodZone.Web.Areas.Admin.ViewModels
{
    public class ReservationViewModel
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [Phone]
        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Trạng thái")]
        public int Status { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [StringLength(255, ErrorMessage = "Tên phải từ {2} đến {1} ký tự", MinimumLength = 3)]
        [Display(Name = "Tên")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [Display(Name = "Ngày đặt bàn")]
        public DateTime ReservationDate { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [Display(Name = "Người lớn")]
        public int Adult { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [Display(Name = "Trẻ Con")]
        public int Child { get; set; }

        [StringLength(500, ErrorMessage = "{0} không lớn hơn 500 ký tự")]
        [Display(Name = "Ghi chú")]
        public string Note { get; set; }

        [StringLength(500, ErrorMessage = "{0} không lớn hơn 500 ký tự")]
        [Display(Name = "Lí do huỷ")]
        public string CancelReason { get; set; }
    }
}