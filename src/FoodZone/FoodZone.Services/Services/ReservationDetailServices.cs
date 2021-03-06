using FoodZone.Data.Infrastructure;
using FoodZone.Models.Common;
using FoodZone.Services.BaseServices;
using FoodZone.Services.IServices;

namespace FoodZone.Services.Services
{
    public class ReservationDetailServices : BaseServices<ReservationDetail>, IReservationDetailsServices
    {
        public ReservationDetailServices(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
