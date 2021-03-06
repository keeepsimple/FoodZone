using FoodZone.Models.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodZone.Models.Common
{
    public class Voucher : BaseEntity
    {
        [Required(ErrorMessage = "The {0} is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        public string Code { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        public string Content { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        public string Image { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        public DateTime ExpiredDate { get; set; }

        public int Status { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        public int Level { get; set; }

        public virtual ICollection<UserVoucher> UserVouchers { get; set; }
    }
}
