using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_end.Models.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Back_end.Models.Data
{
    public class DataContext : DbContext
    {
        public DataContext() {}
        public string DbPath { get; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            string path = Directory.GetCurrentDirectory();
            DbPath = Path.Join(path, "bancoLocal.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite($"Data Source = {DbPath}");

        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Instituto> Institutos { get; set; }
        public DbSet<MaterialDoacao> MateriaisDoacao { get; set; }
        public DbSet<PontoDoacao> PontoDoacao { get; set; }
        public DbSet<Voluntariado> Voluntariados { get; set; }
        public DbSet<VoluntariadoBeneficio> VoluntariadoBeneficios { get; set; }
        public DbSet<VoluntariadoResponsabilidade> VoluntariadoResponsabilidades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Instituto>()
                .HasOne(i => i.Endereco)
                .WithOne(e => e.Instituto)
                .HasForeignKey<Endereco>(e => e.InstitutoId);

            modelBuilder.Entity<Endereco>()
                .HasOne(e => e.PontoDoacao)
                .WithOne(pd => pd.Endereco)
                .HasForeignKey<PontoDoacao>(pd => pd.EnderecoId);

            modelBuilder.Entity<PontoDoacao>()
                .HasOne(pd => pd.MaterialDoacao)
                .WithOne(md => md.PontoDoacao)
                .HasForeignKey<MaterialDoacao>(md => md.PontoDoacaoId);
        }

    }
}