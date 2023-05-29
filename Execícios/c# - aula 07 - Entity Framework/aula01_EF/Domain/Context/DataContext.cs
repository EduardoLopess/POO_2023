using aula01_EF.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace aula01_EF.Domain.Context
{
    public class DataContext : DbContext
    {
        protected string DbPath { get; }
        public DataContext()
        {
            string path = Directory.GetCurrentDirectory();
            DbPath = System.IO.Path.Join(path, "testeORM.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        public DbSet<Person> Person {get; set;}
    }
}