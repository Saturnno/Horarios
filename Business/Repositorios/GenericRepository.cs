using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Business.Intefaces;
using System.Data.Entity;

namespace Business.Repositorios
{
    public class GenericRepository<T, TContext> : IRepository<T>, IDisposable where T : class where TContext : DbContext, new()
    {
        private readonly DbContext _context;
        public GenericRepository()
        {
            _context = new TContext();
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public IQueryable<T> AsQueryable()
        {
            return _context.Set<T>();
        }

        public void Delete(T entity)
        {
            _context.Entry<T>(entity).State = EntityState.Deleted;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public T Find(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicado)
        {
            return _context.Set<T>().Where(predicado);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public void Update(T entity)
        {
            _context.Entry<T>(entity).State = EntityState.Modified;
        }
    }
}
