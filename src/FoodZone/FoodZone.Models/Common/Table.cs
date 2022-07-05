using FoodZone.Models.BaseEntities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodZone.Models.Common
{
    public class Table : BaseEntity
    {
        [Required(ErrorMessage = "The {0} is required")]
        public int Floor { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        public int NumberTable { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        public int Capacity { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        public int Status { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
