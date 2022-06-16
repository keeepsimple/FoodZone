using FoodZone.Models.BaseEntities;
using FoodZone.Models.Security;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodZone.Models.Common
{
    [Table("Salaries", Schema = "common")]
    public class Salary : BaseEntity
    {
        [Required(ErrorMessage = "The {0} is required")]
        public decimal BasicSalary { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(255, ErrorMessage = "The {0} must between {2} and {1} characters", MinimumLength = 3)]
        public string Name { get; set; }

        public string? AccountId { get; set; }

        public Account Account { get; set; }
    }
}
