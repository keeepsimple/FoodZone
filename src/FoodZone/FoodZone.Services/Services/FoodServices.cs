using FoodZone.Data.Infrastructure;
using FoodZone.Models.Common;
using FoodZone.Services.BaseServices;
using FoodZone.Services.IServices;
using System.Collections.Generic;
using System.Linq;

namespace FoodZone.Services.Services
{
    public class FoodServices : BaseServices<Food>, IFoodServices
    {
        public FoodServices(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<Food> GetFoodByMenu(int menuId)
        {
            return _unitOfWork.FoodRepository.GetQuery(f => f.MenuFoods.Any(m => m.MenuId == menuId)).ToList();
        }
    }
}
