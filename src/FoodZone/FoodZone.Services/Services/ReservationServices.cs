using FoodZone.Data.Infrastructure;
using FoodZone.Models.Common;
using FoodZone.Services.BaseServices;
using FoodZone.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodZone.Services.Services
{
    public class ReservationServices : BaseServices<Reservation>, IReservationServices
    {
        public ReservationServices(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<Reservation> GetAllReservationToday()
        {
            var today = DateTime.Now.ToShortDateString();
            var getDate = DateTime.Parse(today);
            return _unitOfWork.ReservationRepository.GetQuery(x => x.ReservationDate == getDate).OrderByDescending(x=>x.ReservationDate).ToList();
        }
    }
}
