using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Models;

namespace Store.Configuration
{
    public class MClientConfig : IEntityTypeConfiguration<MClient>
    {
        public void Configure(EntityTypeBuilder<MClient> builder)
        {
            builder.ToTable("Clients");
            builder.HasKey(c => c.IdClient);
            builder.Property(c => c.DNI).HasMaxLength(100).IsRequired();
            builder.Property(c => c.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(c => c.LastName).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Direction).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Phone).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Email).HasMaxLength(100).IsRequired();
            builder.Property(c => c.City).HasMaxLength(100).IsRequired();
        }
    }
}
