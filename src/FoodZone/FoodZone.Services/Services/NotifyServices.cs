using FoodZone.Data.Infrastructure;
using FoodZone.Models.Common;
using FoodZone.Services.BaseServices;
using FoodZone.Services.IServices;

namespace FoodZone.Services.Services
{
    public class NotifyServices : BaseServices<Notify>, INotifyServices
    {
        public NotifyServices(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
