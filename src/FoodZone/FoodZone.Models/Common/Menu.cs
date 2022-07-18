using FoodZone.Models.BaseEntities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodZone.Models.Common
{
    public class Menu : BaseEntity
    {
        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(255, ErrorMessage = "The {0} must between {2} and {1} characters", MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(500, ErrorMessage = "The {0} must less than {1} characters")]
        public string Description { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<MenuCategory> MenuCategories { get; set; }

        public virtual ICollection<UserMenu> UserMenus { get; set; }
    }
}
