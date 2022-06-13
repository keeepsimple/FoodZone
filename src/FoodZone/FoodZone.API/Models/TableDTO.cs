using System.ComponentModel.DataAnnotations;

namespace FoodZone.API.Models
{
    public class TableDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        public int Capacity { get; set; }

        public int Status { get; set; }
    }
}
