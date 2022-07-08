using FoodZone.Models.Common;
using FoodZone.Services.BaseServices;
using System.Collections.Generic;

namespace FoodZone.Services.IServices
{
    public interface IFoodServices : IBaseServices<Food>
    {
        IEnumerable<Food> GetFoodsByCategory(int categoryId);
    }
}
