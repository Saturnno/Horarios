using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Business.Intefaces
{
    public interface IRepository<T> where T:class
    {
        IQueryable<T> AsQueryable();
        IEnumerable<T> GetAll();
        IEnumerable<T> Get(Expression<Func<T, bool>> predicado);
        T Find(int id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        void SaveChanges();
    }
}
