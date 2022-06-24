using FoodZone.Data.Infrastructure;
using FoodZone.Models.Common;
using FoodZone.Services.BaseServices;
using FoodZone.Services.IServices;

namespace FoodZone.Services.Services
{
    public class MenuFoodServices : BaseServices<MenuFood>, IMenuFoodServices
    {
        public MenuFoodServices(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
