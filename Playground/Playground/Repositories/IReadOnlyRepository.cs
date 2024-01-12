using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Lambda.InputDb.Interfaces
{
    public interface IReadOnlyRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null);

        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null);

        TEntity GetSingleOrDefault(Expression<Func<TEntity, bool>> filter = null);

        TEntity GetFirstOrDefault(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

        TEntity GetById(object id);

        int Count(Expression<Func<TEntity, bool>> filter = null);

        bool Exists(Expression<Func<TEntity, bool>> filter = null);
    }
}
