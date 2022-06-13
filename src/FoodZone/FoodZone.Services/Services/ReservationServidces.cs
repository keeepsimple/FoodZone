using FoodZone.Data.Infrastructure;
using FoodZone.Models.Common;
using FoodZone.Services.BaseServices;
using FoodZone.Services.IServices;

namespace FoodZone.Services.Services
{
    public class ReservationServidces : BaseServices<Reservation>, IReservationServices
    {
        public ReservationServidces(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
