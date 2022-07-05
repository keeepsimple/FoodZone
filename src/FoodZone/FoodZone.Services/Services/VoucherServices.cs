using FoodZone.Data.Infrastructure;
using FoodZone.Models.Common;
using FoodZone.Services.BaseServices;
using FoodZone.Services.IServices;

namespace FoodZone.Services.Services
{
    public class VoucherServices : BaseServices<Voucher>, IVoucherServices
    {
        public VoucherServices(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
