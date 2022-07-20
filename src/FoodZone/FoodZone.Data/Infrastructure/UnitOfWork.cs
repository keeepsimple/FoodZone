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

        private ICoreRepository<News> _blogRepository;
        public ICoreRepository<News> BlogRepository => _blogRepository ?? new CoreRepository<News>(_dbContext);

        private ICoreRepository<Menu> _menuRepository;
        public ICoreRepository<Menu> MenuRepository => _menuRepository ?? new CoreRepository<Menu>(_dbContext);

        private ICoreRepository<Food> _foodRepository;
        public ICoreRepository<Food> FoodRepository => _foodRepository ?? new CoreRepository<Food>(_dbContext);

        private ICoreRepository<MenuCategory> _menuCategoryRepository;
        public ICoreRepository<MenuCategory> MenuCategoryRepository => _menuCategoryRepository ?? new CoreRepository<MenuCategory>(_dbContext);

        private ICoreRepository<Category> _categoryRepository;  
        public ICoreRepository<Category> CategoryRepository => _categoryRepository ?? new CoreRepository<Category>(_dbContext);

        private ICoreRepository<ReservationDetail> _reservationDetailRepository;
        public ICoreRepository<ReservationDetail> ReservationDetailRepository => _reservationDetailRepository ?? new CoreRepository<ReservationDetail>(_dbContext);

        private ICoreRepository<Reservation> _reservationRepository;
        public ICoreRepository<Reservation> ReservationRepository => _reservationRepository ?? new CoreRepository<Reservation>(_dbContext);

        private ICoreRepository<Table> _tableRepository;
        public ICoreRepository<Table> TableRepository => _tableRepository ?? new CoreRepository<Table>(_dbContext);

        private ICoreRepository<UserMenu> _userMenuRepository;
        public ICoreRepository<UserMenu> UserMenuRepository => _userMenuRepository ?? new CoreRepository<UserMenu>(_dbContext);

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
