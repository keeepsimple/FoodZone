using System.ComponentModel.DataAnnotations;

namespace FoodZone.Services.DTO
{
    public class LoginUserDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(32, ErrorMessage = "The {0} must between {2} and {1} characters", MinimumLength = 8)]
        public string Password { get; set; }
    }

    public class AccountDTO : LoginUserDTO
    {
        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(255, ErrorMessage = "The {0} must between {2} and {1} characters", MinimumLength = 3)]
        public string FullName { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }


}
