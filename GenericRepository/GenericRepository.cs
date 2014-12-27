using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericRepository
{
    public interface IGenericRepository<T>:IDisposable where T : class
    {
        IQueryable<T> Select();

        IEnumerable<T> GetAll();

        IEnumerable<T> Where(Func<T, bool> predicate);

        T GetSingle(Func<T, bool> predicate);

        T GetFirst(Func<T, bool> predicate);

        T Add(T entity);

        void Delete(T entity);

        void Attach(T entity);
    }

    public class GenericRepository<T> : IGenericRepository<T>
        where T : class
    {
        private readonly IUnitOfWork _context;

        public GenericRepository(IUnitOfWork context)
        {
            _context = context;
        }

        public IQueryable<T> Select()
        {
            return _context.Set<T>().AsQueryable();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsEnumerable();
        }

        public IEnumerable<T> Where(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public T GetSingle(Func<T, bool> predicate)
        {
            return _context.Set<T>().Single(predicate);
        }

        public T GetFirst(Func<T, bool> predicate)
        {
            return _context.Set<T>().First(predicate);
        }

        public T Add(T entity)
        {
            return _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Attach(T entity)
        {
            _context.Set<T>().Attach(entity);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}