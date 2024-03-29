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
        public string Time { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [Range(1, int.MaxValue, ErrorMessage = "Vui lòng nhập giá trị lớn hơn {1}")]
        [Display(Name = "Số lượng bàn")]
        public int Capacity { get; set; }

        public int CodeId { get; set; }

        public string Note { get; set; }

        [Required(ErrorMessage = "Chưa chọn bàn")]
        public string TableFloorCapacity { get; set; }

        public int MenuId { get; set; }
    }
}