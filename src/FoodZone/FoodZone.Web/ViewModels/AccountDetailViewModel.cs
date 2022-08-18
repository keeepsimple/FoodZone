using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace FoodZone.Web.ViewModels
{
    public class AccountDetailViewModel
    {
        public string UserId { get; set; }


        public string Username { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [StringLength(255, ErrorMessage = "Tên phải từ {2} đến {1} ký tự", MinimumLength = 3)]
        [Display(Name = "Tên đầy đủ")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [RegularExpression("^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$", ErrorMessage = "Email không hợp lệ")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [RegularExpression("^((\\+84|84|0)?((3[2-9]|5[25689]|7[0|6-9]|8[0-9]|9[0-4|6-9]|2[0-9])|(12[0-9]|16[2-9]|18[68]|199)))([0-9]{7})$", ErrorMessage = "Số điện thoại không hợp lệ")]
        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }

        public int Level { get; set; }
    }
}