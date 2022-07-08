using FoodZone.Models.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodZone.Models.Common
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Food> Foods { get; set; }

        public virtual ICollection<MenuCategory> MenuCategories { get; set; }
    }
}
