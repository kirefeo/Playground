using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Lambda.InputDb.Interfaces;

namespace Lambda.InputDb.Repositories
{
    public class EfRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        private readonly IDbContextFactory<TContext> _dbContextFactory;

        public EfRepository(IDbContextFactory<TContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public virtual void Add(TEntity entity)
        {
            using (var context = _dbContextFactory.Create())
            {
                context.Set<TEntity>().Add(entity);
            }
        }

        public virtual void AddRange(IList<TEntity> entities)
        {
            using (var context = _dbContextFactory.Create())
            {
                context.Set<TEntity>().AddRange(entities);
            }
        }

        public virtual void Remove(TEntity entity)
        {
            using (var context = _dbContextFactory.Create())
            {
                context.Set<TEntity>().Remove(entity);
            }
        }

        public virtual void RemoveRange(IList<TEntity> entities)
        {
            using (var context = _dbContextFactory.Create())
            {
                context.Set<TEntity>().RemoveRange(entities);
            }
        }

        public virtual void Save()
        {
            using (var context = _dbContextFactory.Create())
            {
                context.SaveChanges();
            }
        }
    }
}
