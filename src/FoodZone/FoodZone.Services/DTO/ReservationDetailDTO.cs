using System.ComponentModel.DataAnnotations;

namespace FoodZone.Services.DTO
{
    public class ReservationDetailDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        public int Capacity { get; set; }

        public decimal Price { get; set; }

        public int FoodId { get; set; }

        public int ReservationId { get; set; }
    }
}
