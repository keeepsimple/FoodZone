using FoodZone.Data.Infrastructure;
using FoodZone.Data.Infrastructure.Repositories;
using FoodZone.Models.Common;
using FoodZone.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodZone.Services.Services
{
    public class CheckoutServices : ICheckoutServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICoreRepository<Reservation> _reservationRepository; 
        private readonly ICoreRepository<ReservationDetail> _reservationDetailsRepository;

        public CheckoutServices(IUnitOfWork unitOfWork, ICoreRepository<Reservation> reservationRepository, ICoreRepository<ReservationDetail> reservationDetailsRepository)
        {
            _unitOfWork = unitOfWork;
            _reservationRepository = reservationRepository;
            _reservationDetailsRepository = reservationDetailsRepository;
        }

        public void Checkout(Reservation reservation, List<ReservationDetail> reservationDetails)
        {
            _reservationRepository.Add(reservation);

            foreach (var item in reservationDetails)
            {
                item.Reservation = reservation;
                _reservationDetailsRepository.Add(item);
            }

            _unitOfWork.SaveChanges();
        }
    }
}
