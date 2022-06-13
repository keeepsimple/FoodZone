using FoodZone.Data.Infrastructure;
using FoodZone.Models.Common;
using FoodZone.Services.BaseServices;
using FoodZone.Services.IServices;

namespace FoodZone.Services.Services
{
    public class MenuServices : BaseServices<Menu>, IMenuServices
    {
        public MenuServices(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
