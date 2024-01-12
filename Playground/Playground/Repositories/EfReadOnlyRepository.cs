using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using Lambda.InputDb.Interfaces;

namespace Lambda.InputDb.Repositories
{
    public class EfReadOnlyRepository<TEntity, TContext> : IReadOnlyRepository<TEntity> 
    where TEntity : class
    where TContext : DbContext
    {
        private readonly IDbContextFactory<TContext> _dbContextFactory;

        public EfReadOnlyRepository(IDbContextFactory<TContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        protected virtual IQueryable<TEntity> GetQueryable(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        int? skip = null,
        int? take = null)
        {
            using (var context = _dbContextFactory.Create())
            {
                IQueryable<TEntity> query = context.Set<TEntity>();

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                if (orderBy != null)
                {
                    query = orderBy(query);
                }

                if (skip.HasValue)
                {
                    query = query.Skip(skip.Value);
                }

                if (take.HasValue)
                {
                    query = query.Take(take.Value);
                }

                return query;
            }
        }

        public virtual IEnumerable<TEntity> GetAll(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null)
        {
            return GetQueryable(null, orderBy, skip, take).ToList();
        }

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null)
        {
            return GetQueryable(filter, orderBy, skip, take).ToList();
        }

        public virtual TEntity GetSingleOrDefault(Expression<Func<TEntity, bool>> filter = null)
        {
            return GetQueryable(filter).SingleOrDefault();
        }

        public virtual TEntity GetFirstOrDefault(
           Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            return GetQueryable(filter, orderBy).FirstOrDefault();
        }

        public virtual TEntity GetById(object id)
        {
            using (var context = _dbContextFactory.Create())
            {
                return context.Set<TEntity>().Find(id);
            }
        }

        public virtual int Count(Expression<Func<TEntity, bool>> filter = null)
        {
            return GetQueryable(filter).Count();
        }

        public virtual bool Exists(Expression<Func<TEntity, bool>> filter = null)
        {
            return GetQueryable(filter).Any();
        }
    }
}
