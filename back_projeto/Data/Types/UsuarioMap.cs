using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Types
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");
            builder.HasKey(u => u.Id); 

            builder.Property(u => u.Id)
                .HasColumnName("Id")
                .IsRequired()
                .ValueGeneratedOnAdd(); 

            builder.Property(u => u.Nome)
                .HasColumnName("Nome")
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(u => u.SobreNome)
                .HasColumnName("SobreNome")
                .HasMaxLength(100);

            builder.Property(u => u.Telefone)
                .HasColumnName("Telefone")
                .HasMaxLength(20);

            builder.Property(u => u.CPF)
                .HasColumnName("CPF")
                .HasMaxLength(14); 

            builder.Property(u => u.Email)
                .HasColumnName("Email")
                .HasMaxLength(255);

            // Relação de um usuário para muitos endereços (1:N)
            builder.HasMany(u => u.Enderecos)
                .WithOne(e => e.Usuario)
                .HasForeignKey(e => e.UsuarioId); 
        }

    }
}