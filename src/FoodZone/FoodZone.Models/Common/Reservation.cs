using FoodZone.Models.BaseEntities;
using FoodZone.Models.Sercurity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodZone.Models.Common
{
    [Table("Reservations", Schema = "common")]
    public class Reservation : BaseEntity
    {
        public DateTime ReservationDate { get; set; }

        public int Status { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(255, ErrorMessage = "The {0} must between {2} and {1} characters", MinimumLength = 3)]
        public string CancelReason { get; set; }

        public string AccountId { get; set; }

        public Account Account { get; set; }

        public virtual ICollection<ReservationDetail> ReservationDetails { get; set; }
        
        public virtual ICollection<Table> Tables { get; set; }
    }
}
