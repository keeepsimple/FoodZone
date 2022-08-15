using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodZone.Web.Areas.Admin.ViewModels
{
    public class AutoCreateTableModel
    {
        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [Range(1, int.MaxValue, ErrorMessage = "Vui lòng nhập giá trị lớn hơn {1}")]
        [Display(Name = "Số lượng bàn")]
        public int NumberOfTable { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [Range(1, int.MaxValue, ErrorMessage = "Vui lòng nhập giá trị lớn hơn {1}")]
        [Display(Name = "Tầng")]
        public int Floor { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [Display(Name = "Sức chứa")]
        public string Capacities { get; set; }
    }
}