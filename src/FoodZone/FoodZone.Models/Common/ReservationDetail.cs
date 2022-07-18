using FoodZone.Models.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodZone.Models.Common
{
    public class ReservationDetail:BaseEntity
    {
        public int TableId { get; set; }

        public Table Table { get; set; }

        public int ReservationId { get; set; }

        public Reservation Reservation { get; set; }

        public int MenuId { get; set; }

        public Menu Menu { get; set; }

        public int? FoodId { get; set; }

        public Food Food { get; set; }

        public decimal MenuPrice { get; set; }

        public decimal? FoodPrice { get; set; }
    }
}
