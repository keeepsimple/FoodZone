using FoodZone.Models.BaseEntities;
using FoodZone.Models.Security;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodZone.Models.Common
{
    [Table("Payment", Schema = "common")]
    public class Payment : BaseEntity
    {
        public string TransactionHistory { get; set; }

        public DateTime PayDate { get; set; }

        public string AccountId { get; set; }

        public Account Account { get; set; }
    }
}
