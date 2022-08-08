using FoodZone.Data.Infrastructure;
using FoodZone.Models.Common;
using FoodZone.Services.BaseServices;
using FoodZone.Services.IServices;
using System.Linq;

namespace FoodZone.Services.Services
{
    public class VoucherServices : BaseServices<Voucher>, IVoucherServices
    {
        public VoucherServices(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public Voucher GetByCode(string code)
        {
            return _unitOfWork.VoucherRepository.GetQuery(x => x.Code == code).FirstOrDefault();
        }
    }
}
