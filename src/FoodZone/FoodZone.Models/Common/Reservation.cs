using FoodZone.Models.BaseEntities;
using FoodZone.Models.Security;
using System;
using System.Collections.Generic;

namespace FoodZone.Models.Common
{
    public class Reservation : BaseEntity
    {
        public string UserId { get; set; }

        public User User { get; set; }

        public string PhoneNumber { get; set; }

        public int Status { get; set; }

        public decimal TotalPrice { get; set; }

        public string Name { get; set; }

        public DateTime ReservationDate { get; set; }

        public int Adult { get; set; }

        public int Child { get; set; }

        public string Note { get; set; }

        public virtual ICollection<Notify> Notifies { get; set; }

        public virtual ICollection<ReservationDetail> ReservationDetails { get; set; }
    }
}
