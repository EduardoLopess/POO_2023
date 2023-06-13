using apiAS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace apiAS.Data.Types
{
    public class SaleMap : IEntityTypeConfiguration<Sale>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Venda");

            builder.Property(s => s.IdSale)
                .HasColumnName("Id")
                .IsRequired();
            builder.HasKey(s => s.IdSale);

            builder.Property(s => s.TotalPrice)
                .HasColumnName("ValorTotal")
                .HasColumnType("decimal")
                .IsRequired();

            builder.Property(s => s.ClientId)
                .IsRequired();

            builder.HasOne(s => s.Client)
                .WithMany()
                .HasForeignKey(s => s.ClientId)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasMany(s => s.Products);
                
               
        }
    }
}