using FoodZone.Models.BaseEntities;
using FoodZone.Models.Security;

namespace FoodZone.Models.Common
{
    public class UserFood : BaseEntity
    {
        public string UserId { get; set; }

        public User User { get; set; }

        public int FoodId { get; set; }

        public Food Food { get; set; }

        public string Comment { get; set; }

        public int Rate { get; set; }
    }
}
