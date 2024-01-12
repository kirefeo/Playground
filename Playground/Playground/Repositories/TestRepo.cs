using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Lambda.InputDb.Models;

namespace Lambda.InputDb.Repositories
{
    public class TestRepo
    {
        public TResult Get<TEntity, TResult>(Expression<Func<TEntity, TResult>> selector) where TEntity : class
        {
            using (var context = new InputDbContext())
            {
                return context.Set<TEntity>().Select(selector).First();
            }
        }

        private void Bla()
        {
            Get<TestTable, int>(test => test.Id);
        }
    }

    internal class InputDbContext : DbContext, IDisposable
    {
    }
}
