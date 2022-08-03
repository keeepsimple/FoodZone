using System.ComponentModel.DataAnnotations;

namespace FoodZone.Web.Areas.Admin.ViewModels
{
    public class NewsViewModel
    {
        public int Id { get; set; }

        public string Image { get; set; }

        [Required(ErrorMessage = "Không để trống")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Không để trống")]
        [StringLength(500, ErrorMessage = "Mô tả ngắn không lớn hơn 500 ký tự")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "Không để trống")]
        [StringLength(255, ErrorMessage = "Tiêu đề phải từ {2} đến {1} ký tự", MinimumLength = 3)]
        public string Title { get; set; }
    }
}