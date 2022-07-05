using FoodZone.Data.Infrastructure;
using FoodZone.Models.Common;
using FoodZone.Services.BaseServices;
using FoodZone.Services.IServices;
using System.Collections.Generic;
using System.Linq;

namespace FoodZone.Services.Services
{
    public class MenuFoodServices : BaseServices<MenuFood>, IMenuFoodServices
    {
        public MenuFoodServices(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<int> GetFoodIdByMenu(int menuId)
        {
            return _unitOfWork.MenuFoodRepository.GetQuery(x => x.MenuId == menuId).Select(m => m.FoodId).ToList();
        }

        public void RemoveMenuFoodsByMenu(int menuId)
        {
            var menuFoods = _unitOfWork.MenuFoodRepository.GetQuery(x => x.MenuId == menuId).ToList();
            _unitOfWork.MenuFoodRepository.Delete(menuFoods, isHardDelete: true);
        }
    }
}
