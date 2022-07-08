using FoodZone.Models.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodZone.Models.Common
{
    public class MenuCategory:BaseEntity
    {
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public int MenuId { get; set; }

        public Menu Menu { get; set; }
    }
}
