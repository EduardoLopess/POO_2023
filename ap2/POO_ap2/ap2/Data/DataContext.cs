using ap2.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ap2.Data
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
    }
}