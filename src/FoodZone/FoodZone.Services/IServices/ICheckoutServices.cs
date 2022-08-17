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
        Task CheckoutAsync(Reservation reservation, List<ReservationDetail> reservationDetails);
    }
}
