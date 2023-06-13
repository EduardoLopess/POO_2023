using apiAS.Data.Types;
using apiAS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace apiAS.Data
{
    public class DataContext : DbContext
    {
        public string DbPath {get; }
        public DataContext()
        {
            string path = Directory.GetCurrentDirectory();
            DbPath = System.IO.Path.Join(path, "bancoLocal.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite($"Data Source={DbPath}");
            
        public DbSet<Client> Clients {get; set;}
        public DbSet<Product> Products {get; set;}
        public DbSet<Sale>  Sales {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new SaleMap());
        }
    }
}