using FoodZone.Models.Common;
using FoodZone.Services.BaseServices;
using System.Collections.Generic;

namespace FoodZone.Services.IServices
{
    public interface IMenuCategoryServices : IBaseServices<MenuCategory>
    {
        void RemoveMenuCategoriesByMenu(int menuId);

        IEnumerable<int> GetCategoryIdByMenu(int menuId);
    }
}
