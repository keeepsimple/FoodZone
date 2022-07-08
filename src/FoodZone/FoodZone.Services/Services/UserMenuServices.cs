using FoodZone.Data.Infrastructure;
using FoodZone.Models.Common;
using FoodZone.Services.BaseServices;
using FoodZone.Services.IServices;

namespace FoodZone.Services.Services
{
    public class UserMenuServices : BaseServices<UserMenu>, IUserMenuServices
    {
        public UserMenuServices(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
