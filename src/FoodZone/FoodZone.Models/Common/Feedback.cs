using FoodZone.Models.BaseEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodZone.Models.Common
{
    [Table("Feedback", Schema = "common")]
    public class Feedback : BaseEntity
    {
        public string Comment { get; set; }

        public int FoodId { get; set; }

        public Food Food { get; set; }
    }
}
