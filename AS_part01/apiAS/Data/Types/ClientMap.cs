using apiAS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace apiAS.Data.Types
{
    public class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Cliente");

            builder.Property(i => i.IdClient)
                .HasColumnName("Id")
                .IsRequired();
            builder.HasKey(i => i.IdClient);

            builder.Property(i => i.Name)
                .HasColumnName("Name")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(i => i.Address)
                .HasColumnName("Address")
                .HasMaxLength(100)
                .IsRequired();        
        }
    }
}