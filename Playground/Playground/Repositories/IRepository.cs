using System.Collections.Generic;

namespace Lambda.InputDb.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        void AddRange(IList<TEntity> entities);

        void Remove(TEntity entity);

        void RemoveRange(IList<TEntity> entities);

        void Save();
    }
}
