using FoodZone.Models.BaseEntities;
using FoodZone.Models.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FoodZone.Models.Common
{
    public class Reservation : BaseEntity
    {
        public string UserId { get; set; }

        public User User { get; set; }

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
        [Display(Name = "Số lượng bàn")]
        public int Capacity { get; set; }

        [StringLength(500, ErrorMessage = "{0} không lớn hơn 500 ký tự")]
        [Display(Name = "Ghi chú")]
        public string Note { get; set; }

        [StringLength(500, ErrorMessage = "{0} không lớn hơn 500 ký tự")]
        [Display(Name = "Lí do huỷ")]
        public string CancelReason { get; set; }

        public virtual ICollection<ReservationDetail> ReservationDetails { get; set; }
    }
}
