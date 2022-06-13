using FoodZone.Data.Infrastructure;
using FoodZone.Models.Common;
using FoodZone.Services.BaseServices;
using FoodZone.Services.IServices;

namespace FoodZone.Services.Services
{
    public class MenuServidces : BaseServices<Menu>, IMenuServices
    {
        public MenuServidces(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
