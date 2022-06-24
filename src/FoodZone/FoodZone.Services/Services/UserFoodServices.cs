using FoodZone.Data.Infrastructure;
using FoodZone.Models.Common;
using FoodZone.Services.BaseServices;
using FoodZone.Services.IServices;

namespace FoodZone.Services.Services
{
    public class UserFoodServices : BaseServices<UserFood>, IUserFoodServices
    {
        public UserFoodServices(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
