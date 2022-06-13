using System.ComponentModel.DataAnnotations;

namespace FoodZone.API.Models
{
    public class ReservationDTO
    {
        public int Id { get; set; }

        public DateTime ReservationDate { get; set; }

        public int Status { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(255, ErrorMessage = "The {0} must between {2} and {1} characters", MinimumLength = 3)]
        public string CancelReason { get; set; }

        public string AccountId { get; set; }
    }
}
