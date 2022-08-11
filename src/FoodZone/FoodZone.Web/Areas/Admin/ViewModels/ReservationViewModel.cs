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

        public string PhoneNumber { get; set; }

        [Display(Name = "Trạng thái")]
        public int Status { get; set; }

        public string Name { get; set; }

        public DateTime ReservationDate { get; set; }

        [Display(Name = "Số người")]
        public int Capacity { get; set; }

        [StringLength(500, ErrorMessage = "{0} không lớn hơn 500 ký tự")]
        [Display(Name = "Ghi chú")]
        public string Note { get; set; }

        [StringLength(500, ErrorMessage = "{0} không lớn hơn 500 ký tự")]
        [Display(Name = "Lí do huỷ")]
        public string CancelReason { get; set; }

        [Display(Name = "Mã khuyến mãi")]
        public string Code { get; set; }
    }
}