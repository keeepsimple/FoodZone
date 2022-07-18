using FoodZone.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodZone.Services.IServices
{
    public interface ICheckoutServices
    {
        void Checkout(Reservation reservation, List<ReservationDetail> reservationDetails);
    }
}
