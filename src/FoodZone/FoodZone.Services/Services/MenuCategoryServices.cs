using FoodZone.Data.Infrastructure;
using FoodZone.Models.Common;
using FoodZone.Services.BaseServices;
using FoodZone.Services.IServices;
using System.Collections.Generic;
using System.Linq;

namespace FoodZone.Services.Services
{
    public class MenuCategoryServices : BaseServices<MenuCategory>, IMenuCategoryServices
    {
        public MenuCategoryServices(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<int> GetCategoryIdByMenu(int menuId)
        {
            return _unitOfWork.MenuCategoryRepository.GetQuery(x => x.MenuId == menuId).Select(m => m.CategoryId).ToList();
        }

        public void RemoveMenuCategoriesByMenu(int menuId)
        {
            var menuCategory = _unitOfWork.MenuCategoryRepository.GetQuery(x => x.MenuId == menuId).ToList();
            _unitOfWork.MenuCategoryRepository.Delete(menuCategory, isHardDelete: true);
        }
    }
}
