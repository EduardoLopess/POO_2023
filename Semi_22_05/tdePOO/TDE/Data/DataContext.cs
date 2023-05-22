using Microsoft.EntityFrameworkCore;
using TDE.Domain.Entities;


namespace TDE.Data
{
    public class DataContext : DbContext
    {
        public string DbPath {get; }

        public DataContext()
        {
            string path = Directory.GetCurrentDirectory();
            DbPath = System.IO.Path.Join(path, "BancoLocal.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite($"Data Source={DbPath}");

        public DbSet<Person> People { get; set; }
        public DbSet<City> Cities { get; set; }    
    }
}