using FoodZone.Models.BaseEntities;
using FoodZone.Models.Security;
using System.Collections.Generic;

namespace FoodZone.Models.Common
{
    public class Reservation : BaseEntity
    {
        public int TableId { get; set; }

        public Table Table { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public string PhoneNumber { get; set; }

        public int Status { get; set; }

        public virtual ICollection<Notify> Notifies { get; set; }
    }
}
