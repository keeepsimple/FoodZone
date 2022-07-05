using FoodZone.Data.Infrastructure.Repositories;
using FoodZone.Models.BaseEntities;
using FoodZone.Models.Common;
using System.Threading.Tasks;

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

        private ICoreRepository<Blog> _blogRepository;
        public ICoreRepository<Blog> BlogRepository => _blogRepository ?? new CoreRepository<Blog>(_dbContext);

        private ICoreRepository<Menu> _menuRepository;
        public ICoreRepository<Menu> MenuRepository => _menuRepository ?? new CoreRepository<Menu>(_dbContext);

        private ICoreRepository<Food> _foodRepository;
        public ICoreRepository<Food> FoodRepository => _foodRepository ?? new CoreRepository<Food>(_dbContext);

        private ICoreRepository<MenuFood> _menuFoodRepository;
        public ICoreRepository<MenuFood> MenuFoodRepository => _menuFoodRepository ?? new CoreRepository<MenuFood>(_dbContext);

        private ICoreRepository<Notify> _notifyRepository;
        public ICoreRepository<Notify> NotifyRepository => _notifyRepository ?? new CoreRepository<Notify>(_dbContext);

        private ICoreRepository<Reservation> _reservationRepository;
        public ICoreRepository<Reservation> ReservationRepository => _reservationRepository ?? new CoreRepository<Reservation>(_dbContext);

        private ICoreRepository<Table> _tableRepository;
        public ICoreRepository<Table> TableRepository => _tableRepository ?? new CoreRepository<Table>(_dbContext);

        private ICoreRepository<UserBlog> _userBlogRepository;
        public ICoreRepository<UserBlog> UserBlogRepository => _userBlogRepository ?? new CoreRepository<UserBlog>(_dbContext);

        private ICoreRepository<UserFood> _userFoodRepository;
        public ICoreRepository<UserFood> UserFoodRepository => _userFoodRepository ?? new CoreRepository<UserFood>(_dbContext);

        private ICoreRepository<UserVoucher> _userVoucherRepository;
        public ICoreRepository<UserVoucher> UserVoucherRepository => _userVoucherRepository ?? new CoreRepository<UserVoucher>(_dbContext);

        private ICoreRepository<Voucher> _voucherRepository;
        public ICoreRepository<Voucher> VoucherRepository => _voucherRepository ?? new CoreRepository<Voucher>(_dbContext);

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

    }
}
