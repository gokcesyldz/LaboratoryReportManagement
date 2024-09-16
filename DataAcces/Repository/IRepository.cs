using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.GenericRepository
{
    public interface IRepository<T>
        {
            Task Add(T entity);
            Task Delete(T entity);
            Task Update(T entity);
            IQueryable<T> Find(Expression<Func<T, bool>> expression);
            List<T> GetAll();

        }
}


