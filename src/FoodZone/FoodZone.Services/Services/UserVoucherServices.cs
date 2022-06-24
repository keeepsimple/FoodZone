using FoodZone.Data.Infrastructure;
using FoodZone.Models.Common;
using FoodZone.Services.BaseServices;
using FoodZone.Services.IServices;

namespace FoodZone.Services.Services
{
    public class UserVoucherServices : BaseServices<UserVoucher>, IUserVoucherServices
    {
        public UserVoucherServices(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
