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

        public IEnumerable<Reservation> GetAllReservationMonthly()
        {
            return _unitOfWork.ReservationRepository.GetQuery(x => x.ReservationDate.Month == DateTime.Now.Month).ToList();
        }

        public IEnumerable<Reservation> GetAllReservationToday()
        {
            var today = DateTime.Now.ToShortDateString();
            var all = _unitOfWork.ReservationRepository.GetQuery().ToList();
            return all.Where(x => x.ReservationDate.ToShortDateString() == today);
        }
    }
}
