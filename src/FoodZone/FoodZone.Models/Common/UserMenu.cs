using FoodZone.Models.BaseEntities;
using FoodZone.Models.Security;

namespace FoodZone.Models.Common
{
    public class UserMenu : BaseEntity
    {
        public string UserId { get; set; }

        public User User { get; set; }

        public int MenuId { get; set; }

        public Menu Menu { get; set; }

        public string Comment { get; set; }

        public int Rate { get; set; }
    }
}
