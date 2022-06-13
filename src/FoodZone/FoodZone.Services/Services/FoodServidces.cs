using FoodZone.Data.Infrastructure;
using FoodZone.Models.Common;
using FoodZone.Services.BaseServices;
using FoodZone.Services.IServices;

namespace FoodZone.Services.Services
{
    public class FoodServidces : BaseServices<Food>, IFoodServices
    {
        public FoodServidces(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
