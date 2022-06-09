using FoodZone.Models.Common;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace FoodZone.Models.Sercurity
{
    public class Account : IdentityUser
    {
        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(255, ErrorMessage = "The {0} must between {2} and {1} characters", MinimumLength = 3)]
        public string FullName { get; set; }

        public int TableId { get; set; }

        public Table Table { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }

        public virtual ICollection<Salary> Salaries { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
