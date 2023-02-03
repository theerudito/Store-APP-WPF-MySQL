using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Models;

namespace Store.Configuration
{
    internal class MCartConfig : IEntityTypeConfiguration<MCart>
    {
        public void Configure(EntityTypeBuilder<MCart> builder)
        {
            builder.ToTable("Cart");
            builder.HasKey(c => c.IdCart);
            builder.Property(c => c.IdClient).HasMaxLength(100).IsRequired();
            builder.Property(c => c.IdProduct).HasMaxLength(100).IsRequired();
            builder.HasOne(x => x.Clients).WithMany(x => x.Cart).HasForeignKey(x => x.IdClient);
            builder.HasOne(x => x.Products).WithMany(x => x.Cart).HasForeignKey(x => x.IdProduct);
        }
    }
}
