﻿using FoodZone.Data.Infrastructure.Repositories;
using FoodZone.Models.BaseEntities;
using FoodZone.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        ICoreRepository<News> BlogRepository { get; }

        ICoreRepository<Menu> MenuRepository { get; }

        ICoreRepository<Food> FoodRepository { get; }

        ICoreRepository<Category> CategoryRepository { get; }

        ICoreRepository<MenuCategory> MenuCategoryRepository { get; }

        ICoreRepository<ReservationDetail> ReservationDetailRepository { get; }

        ICoreRepository<Reservation> ReservationRepository { get; }

        ICoreRepository<Table> TableRepository { get; }

        ICoreRepository<UserVoucher> UserVoucherRepository { get; }

        ICoreRepository<Voucher> VoucherRepository { get; }

        #endregion

    }
}
