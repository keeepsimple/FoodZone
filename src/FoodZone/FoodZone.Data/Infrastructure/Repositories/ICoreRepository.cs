using System.Linq.Expressions;

namespace FoodZone.Data.Infrastructure.Repositories
{
    public interface ICoreRepository<TEntity>
    {
        Task<TEntity> GetByIdAsync(int id);

        TEntity GetById(int id);

        void Add(TEntity entity);

        void Add(IEnumerable<TEntity> entities);

        void Delete(TEntity entity, bool isHardDelete = false);

        void Delete(IEnumerable<TEntity> entities, bool isHardDelete = false);

        IQueryable<TEntity> GetQuery();

        IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> where);

        void Update(TEntity entity);
    }
}
