using FoodZone.Models.Common;
using FoodZone.Services.BaseServices;

namespace FoodZone.Services.IServices
{
    public interface IVoucherServices : IBaseServices<Voucher>
    {
        Voucher GetByCode(string code);
    }
}
