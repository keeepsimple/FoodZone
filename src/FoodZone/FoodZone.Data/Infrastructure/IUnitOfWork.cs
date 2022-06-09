using FoodZone.Data.Infrastructure.Repositories;
using FoodZone.Models.BaseEntities;
using FoodZone.Models.Common;
using System;
using System.Threading.Tasks;

namespace FoodZone.Data.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        FoodZoneContext DataContext { get; }

        int SaveChanges();

        Task<int> SaveChangesAsync();

        ICoreRepository<T> CoreRepository<T>() where T : BaseEntity;

        #region Master Data

        ICoreRepository<Menu> MenuRepository { get; }

        ICoreRepository<ReservationDetail> ReservationDetailRepository { get; }

        ICoreRepository<Food> FoodRepository { get; }

        ICoreRepository<Reservation> ReservationRepository { get; }

        ICoreRepository<Feedback> FeedbackRepository { get; }

        ICoreRepository<Payment> PaymentRepository { get; }

        ICoreRepository<Salary> SalaryRepository { get; }

        ICoreRepository<Table> TableRepository { get; }

        #endregion

    }
}
