using FoodZone.Models.BaseEntities;

namespace FoodZone.Models.Common
{
    public class MenuFood : BaseEntity
    {
        public int FoodId { get; set; }

        public Food Food { get; set; }

        public int MenuId { get; set; }

        public Menu Menu { get; set; }
    }
}
