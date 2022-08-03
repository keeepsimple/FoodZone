using FoodZone.Data.Infrastructure;
using FoodZone.Models.Common;
using FoodZone.Services.BaseServices;
using FoodZone.Services.IServices;
using System.Collections.Generic;
using System.Linq;

namespace FoodZone.Services.Services
{
    public class ReservationDetailServices : BaseServices<ReservationDetail>, IReservationDetailsServices
    {
        public ReservationDetailServices(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<ReservationDetail> GetReservationDetailsByReservation(int reservationId)
        {
            return _unitOfWork.ReservationDetailRepository.GetQuery(x => x.ReservationId == reservationId).ToList();
        }
    }
}
