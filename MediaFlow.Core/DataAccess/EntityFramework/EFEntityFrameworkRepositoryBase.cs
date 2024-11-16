using MediaFlow.Core.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MediaFlow.Core.DataAccess.EntityFramework
{
    public class EFEntityFrameworkRepositoryBase<TEntity, TContext>
        : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext
    {
        private readonly TContext context;
        public EFEntityFrameworkRepositoryBase(TContext context)
        {
            this.context = context;
        }

        public async Task Add(TEntity entity)
        {
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            await context.SaveChanges();
        }

        public async Task Delete(TEntity entity)
        {
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            await context.SaveChanges();
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            return await context.Set<TEntity>().SingleOrDefault(filter);
        }

        public async Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null ?
                await context.Set<TEntity>().ToList() :
                await context.Set<TEntity>().Where(filter).ToList();
        }

        public async Task Update(TEntity entity)
        {
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Modified;
            await context.SaveChanges();
        }
    }

}
