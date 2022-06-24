using FoodZone.Models.BaseEntities;
using FoodZone.Models.Security;

namespace FoodZone.Models.Common
{
    public class UserBlog : BaseEntity
    {
        public int BlogId { get; set; }

        public Blog Blog { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public string Comment { get; set; }
    }
}
