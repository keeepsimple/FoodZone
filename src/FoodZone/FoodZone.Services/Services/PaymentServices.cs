using FoodZone.Data.Infrastructure;
using FoodZone.Models.Common;
using FoodZone.Services.BaseServices;
using FoodZone.Services.IServices;

namespace FoodZone.Services.Services
{
    public class PaymentServices : BaseServices<Payment>, IPaymentServices
    {
        public PaymentServices(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
