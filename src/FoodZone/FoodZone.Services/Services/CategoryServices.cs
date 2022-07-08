using FoodZone.Data.Infrastructure;
using FoodZone.Models.Common;
using FoodZone.Services.BaseServices;
using FoodZone.Services.IServices;
using System.Collections.Generic;
using System.Linq;

namespace FoodZone.Services.Services
{
    public class CategoryServices : BaseServices<Category>, ICategoryServices
    {
        public CategoryServices(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<Category> GetCategoryByMenu(int menuId)
        {
            return _unitOfWork.CategoryRepository.GetQuery(x => x.MenuCategories.Any(c => c.MenuId == menuId)).ToList();
        }
    }
}
