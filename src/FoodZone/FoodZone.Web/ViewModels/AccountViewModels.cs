using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodZone.Web.ViewModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [StringLength(255, ErrorMessage = "Tên phải từ {2} đến {1} ký tự", MinimumLength = 3)]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [StringLength(255, ErrorMessage = "Tên phải từ {2} đến {1} ký tự", MinimumLength = 3)]
        [Display(Name = "Tên đầy đủ")]
        public string Fullname { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [RegularExpression("^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$", ErrorMessage = "Email không hợp lệ")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [RegularExpression("^((\\+84|84|0)?((3[2-9]|5[25689]|7[0|6-9]|8[0-9]|9[0-4|6-9]|2[0-9])|(12[0-9]|16[2-9]|18[68]|199)))([0-9]{7})$", ErrorMessage = "Số điện thoại không hợp lệ")]
        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [StringLength(100, ErrorMessage = "Tên phải từ {2} đến {1} ký tự", MinimumLength = 6)]
        [DataType(DataType.Password, ErrorMessage ="Mật khẩu không hợp lệ")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Mật khẩu và xác nhận mật khẩu không giống nhau.")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [StringLength(100, ErrorMessage = "{0} phải dài ít nhất {2} ký tự.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("Password", ErrorMessage = "Mật khẩu và xác nhận mật khẩu không giống nhau.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [RegularExpression("^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$", ErrorMessage = "Email không hợp lệ")]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}