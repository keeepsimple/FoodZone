using System.ComponentModel.DataAnnotations;

namespace FoodZone.Web.Areas.Admin.ViewModels
{
    public class TableViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Không để trống")]
        public int Floor { get; set; }

        [Required(ErrorMessage = "Không để trống")]
        public int NumberTable { get; set; }

        [Required(ErrorMessage = "Không để trống")]
        public int Capacity { get; set; }

        public int Status { get; set; }
    }
}