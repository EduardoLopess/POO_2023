using apiAS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace apiAS.Data.Types
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Produto");

            builder.Property(i => i.IdProduct)
                .HasColumnName("Id")
                .IsRequired();
            builder.HasKey(i => i.IdProduct);

            builder.Property(i => i.Name)
                .HasColumnName("Name")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(i => i.Price)
                .HasColumnName("Price")
                .HasColumnType("decimal")
                .IsRequired();        
        }
    }
}