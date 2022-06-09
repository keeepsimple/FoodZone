using FoodZone.Data.Infrastructure.Repositories;
using FoodZone.Models.BaseEntities;
using FoodZone.Models.Common;

namespace FoodZone.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FoodZoneContext _dbContext;
        public FoodZoneContext DataContext => _dbContext;

        public UnitOfWork(FoodZoneContext dbContext)
        {
            _dbContext = dbContext;
        }

        private ICoreRepository<Menu> _menuRepository;
        public ICoreRepository<Menu> MenuRepository => _menuRepository ?? new CoreRepository<Menu>(_dbContext);

        private ICoreRepository<ReservationDetail> _reservationDetailRepository;
        public ICoreRepository<ReservationDetail> ReservationDetailRepository => _reservationDetailRepository ?? new CoreRepository<ReservationDetail>(_dbContext);

        private ICoreRepository<Food> _foodRepository;
        public ICoreRepository<Food> FoodRepository => _foodRepository ?? new CoreRepository<Food>(_dbContext);

        private ICoreRepository<Reservation> _reservationRepository;
        public ICoreRepository<Reservation> ReservationRepository => _reservationRepository ?? new CoreRepository<Reservation>(_dbContext);

        private ICoreRepository<Feedback> _feedbackRepository;
        public ICoreRepository<Feedback> FeedbackRepository => _feedbackRepository ?? new CoreRepository<Feedback>(_dbContext);

        private ICoreRepository<Salary> _salaryRepository;
        public ICoreRepository<Salary> SalaryRepository => _salaryRepository ?? new CoreRepository<Salary>(_dbContext);

        private ICoreRepository<Table> _tableRepository;
        public ICoreRepository<Table> TableRepository => _tableRepository ?? new CoreRepository<Table>(_dbContext);

        private ICoreRepository<Payment> _paymentRepository;
        public ICoreRepository<Payment> PaymentRepository => _paymentRepository ?? new CoreRepository<Payment>(_dbContext);

        #region Method

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public ICoreRepository<T> CoreRepository<T>() where T : BaseEntity
        {
            return new CoreRepository<T>(_dbContext);
        }

        #endregion
    }
}
