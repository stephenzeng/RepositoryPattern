using System;
using System.Data.Entity;

namespace GenericRepository
{
    public interface IUnitOfWork : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
    }

    public interface IDataContext : IUnitOfWork
    {
        DbSet<Customer> Customers { get; set; }
        DbSet<Product> Products { get; set; }
    }

    public class DataContext : DbContext, IDataContext
    {
        public DataContext(string connectionString) : base(connectionString)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
