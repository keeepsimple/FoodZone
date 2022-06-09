using FoodZone.Models.BaseEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodZone.Models.Common
{
    [Table("ReservationDetails", Schema = "common")]
    public class ReservationDetail : BaseEntity
    {
        [Required(ErrorMessage = "The {0} is required")]
        public int Capacity { get; set; }

        public decimal Price { get; set; }

        public int ReservationId { get; set; }

        public Reservation Reservation { get; set; }

        public int FoodId { get; set; }

        public Food Food { get; set; }
    }
}
