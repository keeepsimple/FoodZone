using FoodZone.Models.Common;
using FoodZone.Services.BaseServices;
using System.Collections.Generic;

namespace FoodZone.Services.IServices
{
    public interface IReservationServices : IBaseServices<Reservation>
    {
        IEnumerable<Reservation> GetAllReservationToday();
    }
}
