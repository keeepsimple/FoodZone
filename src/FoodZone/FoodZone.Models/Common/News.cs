using FoodZone.Models.BaseEntities;
using FoodZone.Models.Security;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodZone.Models.Common
{
    public class News : BaseEntity
    {
        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(255, ErrorMessage = "The {0} must between {2} and {1} characters", MinimumLength = 3)]
        public string Image { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        public string Content { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(500, ErrorMessage = "The {0} must less than {1} characters")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(255, ErrorMessage = "The {0} must between {2} and {1} characters", MinimumLength = 3)]
        public string Title { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }
    }
}
