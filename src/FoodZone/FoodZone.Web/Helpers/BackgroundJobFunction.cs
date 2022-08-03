using FoodZone.Data;
using FoodZone.Models.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI.WebControls;

namespace FoodZone.Web.Helpers
{
    public class BackgroundJobFunction
    {

        public void AutoCancelReservation()
        {
            UpdateTable();
            UpdateReservation();
        }

        public void UpdateReservation()
        {
            using (var ctx = new FoodZoneContext())
            {
                var command = "Update Reservations Set Status =4, CancelReason = N'Khách không đến',UpdatedAt = GETDATE() WHERE DATEADD(minute, 15, ReservationDate) <= GETDATE()";
                ctx.Database.ExecuteSqlCommand(command);
            }
        }
        public void UpdateTable()
        {
            using(var ctx = new FoodZoneContext())
            {
                var ids = ctx.Database.SqlQuery<int>("Select t.Id from Tables as t Right Join ReservationDetails as rd on t.Id = rd.TableId right join Reservations as r on rd.ReservationId = r.Id Where DATEADD(minute, 15, r.ReservationDate) <= GETDATE() and r.Status = 1 and t.Status = 1").ToList();
                if(ids.Count() > 0)
                {
                    foreach (var item in ids)
                    {
                        var command = "Update [Tables] Set Status = 0, UpdatedAt = GETDATE() Where Id = @id";
                        var id = new SqlParameter("@id", item);
                        ctx.Database.ExecuteSqlCommand(command, id);
                    }
                }
            }
        }

        public void AutoExpireVoucher()
        {
            using (var ctx = new FoodZoneContext())
            {
                var command = "Update Vouchers Set Status = 0, UpdatedAt = GETDATE() Where ExpiredDate <= GETDATE()";
                ctx.Database.ExecuteSqlCommand(command);
            }
        }
    }
}