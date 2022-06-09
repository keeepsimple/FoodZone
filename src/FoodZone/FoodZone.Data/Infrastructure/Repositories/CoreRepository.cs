﻿using FoodZone.Models.BaseEntities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FoodZone.Data.Infrastructure.Repositories
{
    public class CoreRepository<TEntity> : ICoreRepository<TEntity> where TEntity : class, IBaseEntity
    {
        protected readonly FoodZoneContext _context;
        private readonly DbSet<TEntity> DbSet;

        public CoreRepository(FoodZoneContext context)
        {
            _context = context;
            //Find property with typeof(T) on dataContext
            var typeOfDbSet = typeof(DbSet<TEntity>);
            foreach (var prop in context.GetType().GetProperties())
            {
                if (typeOfDbSet == prop.PropertyType)
                {
                    DbSet = prop.GetValue(context, null) as DbSet<TEntity>;
                    break;
                }
            }

            if (DbSet == null)
            {
                DbSet = context.Set<TEntity>();
            }
        }

        public void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public void Add(IEnumerable<TEntity> entities)
        {
            DbSet.AddRange(entities);
        }

        public void Delete(TEntity entity, bool isHardDelete = false)
        {
            if (isHardDelete)
            {
                DbSet.Remove(entity);
            }
            else
            {
                entity.IsDeleted = true;
                _context.Entry(entity).State = EntityState.Modified;
            }
        }

        public void Delete(IEnumerable<TEntity> entities, bool isHardDelete = false)
        {
            if (isHardDelete)
            {
                DbSet.RemoveRange(entities);
            }
            else
            {
                foreach (var entity in entities)
                {
                    entity.IsDeleted = true;
                }
            }
        }

        public void Delete(Expression<Func<TEntity, bool>> where, bool isHardDelete = false)
        {
            var entities = GetQuery(where).AsEnumerable();

            //use this overload instead of using foreach to improve performance
            Delete(entities, isHardDelete);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual TEntity GetById(int id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<TEntity> GetQuery()
        {
            return DbSet;
        }

        public IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> where)
        {
            return DbSet.Where(where);
        }

        public void Update(TEntity entity)
        {
            //_dbSet.AddOrUpdate(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
