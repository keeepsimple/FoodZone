using FoodZone.Models.Common;
using FoodZone.Services.BaseServices;
using System.Collections.Generic;

namespace FoodZone.Services.IServices
{
    public interface IReservationDetailsServices : IBaseServices<ReservationDetail>
    { 
        IEnumerable<ReservationDetail> GetReservationDetailsByReservation(int reservationId);
    }
}
