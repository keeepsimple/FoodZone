using FoodZone.Models.BaseEntities;
using FoodZone.Models.Security;

namespace FoodZone.Models.Common
{
    public class Notify : BaseEntity
    {
        public string UserId { get; set; }

        public User User { get; set; }

        public int ReservationId { get; set; }

        public Reservation Reservation { get; set; }

        public string Content { get; set; }
    }
}
