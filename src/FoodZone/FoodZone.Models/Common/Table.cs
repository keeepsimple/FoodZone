using FoodZone.Models.BaseEntities;
using FoodZone.Models.Sercurity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodZone.Models.Common
{
    [Table("Tables", Schema = "common")]
    public class Table:BaseEntity
    {
        [Required(ErrorMessage = "The {0} is required")]
        public int Capacity { get; set; }

        public int Status { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
