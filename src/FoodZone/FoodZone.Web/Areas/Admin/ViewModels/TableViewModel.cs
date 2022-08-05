using System.ComponentModel.DataAnnotations;

namespace FoodZone.Web.Areas.Admin.ViewModels
{
    public class TableViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [Range(1, int.MaxValue, ErrorMessage = "Vui lòng nhập giá trị lớn hơn {1}")]
        [Display(Name = "Tầng")]
        public int Floor { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [Range(1, int.MaxValue, ErrorMessage = "Vui lòng nhập giá trị lớn hơn {1}")]
        [Display(Name = "Bàn số")]
        public int NumberTable { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [Range(1, int.MaxValue, ErrorMessage = "Vui lòng nhập giá trị lớn hơn {1}")]
        [Display(Name = "Sức chứa")]
        public int Capacity { get; set; }

        public int Status { get; set; }
    }
}