using FoodZone.Models.BaseEntities;
using FoodZone.Models.Security;

namespace FoodZone.Models.Common
{
    public class UserVoucher : BaseEntity
    {
        public string UserId { get; set; }

        public User User { get; set; }

        public int VoucherId { get; set; }

        public Voucher Voucher { get; set; }
    }
}
