using System.ComponentModel.DataAnnotations;

namespace FoodZone.API.Models
{
    public class MenuDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(255, ErrorMessage = "The {0} must between {2} and {1} characters", MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(255, ErrorMessage = "The {0} must less than {1} characters")]
        public string Description { get; set; }
    }
}
