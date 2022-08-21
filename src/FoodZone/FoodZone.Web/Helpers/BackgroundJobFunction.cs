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
            TableHub.BroadcastData();
            UpdateReservation();
        }

        public void UpdateReservation()
        {
            using (var ctx = new FoodZoneContext())
            {
                var command = "Update Reservations Set Status = -1, CancelReason = N'Khách không đến',UpdatedAt = GETDATE() WHERE DATEADD(minute, 15, ReservationDate) <= GETDATE() and Status = 0";
                ctx.Database.ExecuteSqlCommand(command);
                ctx.SaveChanges();
            }
        }

        public void UpdateTable()
        {
            using (var ctx = new FoodZoneContext())
            {
                var ids = ctx.Database.SqlQuery<int>("Select t.Id from Tables as t Right Join ReservationDetails as rd on t.Id = rd.TableId right join Reservations as r on rd.ReservationId = r.Id Where DATEADD(minute, 15, r.ReservationDate) <= GETDATE() and t.Status = 1 and r.Status = 0").ToList();
                if (ids.Count() > 0)
                {
                    foreach (var item in ids)
                    {
                        var command = "Update [Tables] Set Status = 0, UpdatedAt = GETDATE() Where Id = @id";
                        var id = new SqlParameter("@id", item);
                        ctx.Database.ExecuteSqlCommand(command, id);
                        TableHub.BroadcastData();
                        ctx.SaveChanges();
                    }
                }
            }
        }

        public void ResetAllTable()
        {
            var getToday = DateTime.Now.ToString("MM-dd-yyyy");
            string resetTime = "";
            if (DateTime.Now.Hour < 16)
            {
                resetTime = DateTime.Parse(getToday).AddHours(15).ToString("yyyy-MM-dd HH:mm:ss");
            }
            else
            {
                resetTime = DateTime.Parse(getToday).AddHours(22).ToString("yyyy-MM-dd HH:mm:ss");
            }
            using (var ctx = new FoodZoneContext())
            {
                var command = "Update Tables Set Status = 0, UpdatedAt = GETDATE() WHERE GETDATE() >= @resetTime";
                var reset = new SqlParameter("@resetTime", resetTime);
                ctx.Database.ExecuteSqlCommand(command, reset);
                ctx.SaveChanges();
                TableHub.BroadcastData();
            }
        }

        public void AutoExpireVoucher()
        {
            using (var ctx = new FoodZoneContext())
            {
                var command = "Update Vouchers Set Status = 0, UpdatedAt = GETDATE() Where ExpiredDate <= GETDATE()";
                ctx.Database.ExecuteSqlCommand(command);
                ctx.SaveChanges();
            }
        }
    }
}