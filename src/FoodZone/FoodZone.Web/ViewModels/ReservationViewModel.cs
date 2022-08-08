﻿using FoodZone.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodZone.Web.ViewModels
{
    public class ReservationViewModel
    {
        [Required(ErrorMessage = "Tên khách hàng không được bỏ trống")]
        public string CusName { get; set; }

        [Required(ErrorMessage = "Số điện thoại không được bỏ trống")]
        public string PhoneNumber { get; set; }

        public int Status { get; set; }

        [Required(ErrorMessage = "Ngày đặt bàn không được bỏ trống")]
        public string ReservationDate { get; set; } = DateTime.Now.ToShortDateString();

        [Required(ErrorMessage = "Giờ đặt hàng không được bỏ trống")]
        public int Hours { get; set; }

        [Required(ErrorMessage = "Giờ đặt hàng không được bỏ trống")]
        public int Minute { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [Display(Name = "Số lượng bàn")]
        public int Capacity { get; set; }

        public string Code { get; set; }

        public string Note { get; set; }

        public string TableFloorCapacity { get; set; }

        public int MenuId { get; set; }
    }
}