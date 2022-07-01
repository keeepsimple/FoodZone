using FoodZone.Models.Common;
using FoodZone.Services.BaseServices;
using System.Collections.Generic;

namespace FoodZone.Services.IServices
{
    public interface IMenuFoodServices : IBaseServices<MenuFood>
    {
        void RemoveMenuFoodsByMenu(int menuId);

        IEnumerable<int> GetFoodIdByMenu(int menuId);
    }
}
