using FoodZone.Models.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodZone.Models.Common
{
    public class Category:BaseEntity
    {
        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [StringLength(255, ErrorMessage = "Tên phải từ {2} đến {1} ký tự", MinimumLength = 2)]
        [Display(Name = "Tên")]
        public string Name { get; set; }

        [Display(Name = "Ảnh")]
        public string Image { get; set; }

        public virtual ICollection<Food> Foods { get; set; }

        public virtual ICollection<MenuCategory> MenuCategories { get; set; }
    }
}
