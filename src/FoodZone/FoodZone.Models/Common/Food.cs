using FoodZone.Models.BaseEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodZone.Models.Common
{
    [Table("Food", Schema = "common")]
    public class Food : BaseEntity
    {
        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(255, ErrorMessage = "The {0} must between {2} and {1} characters", MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        public string Image { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(500, ErrorMessage = "The {0} must less than {1} characters")]
        public string Description { get; set; }

        public int Status { get; set; }

        public int RateCount { get; set; }

        public int TotalRate { get; set; }

        public decimal Rate => RateCount == 0 ? 0 : TotalRate / RateCount;

        public int MenuId { get; set; }

        public Menu Menu { get; set; }

        public virtual ICollection<ReservationDetail> ReservationDetails { get; set; }

        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
