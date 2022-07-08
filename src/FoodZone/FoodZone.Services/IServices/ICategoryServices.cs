using FoodZone.Models.Common;
using FoodZone.Services.BaseServices;
using System.Collections.Generic;

namespace FoodZone.Services.IServices
{
    public interface ICategoryServices:IBaseServices<Category>
    {
        IEnumerable<Category> GetCategoryByMenu(int menuId);
    }
}
