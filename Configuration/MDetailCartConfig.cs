using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Models;

namespace Store.Configuration
{
    internal class MDetailCartConfig : IEntityTypeConfiguration<MDetailsCart>
    {
        public void Configure(EntityTypeBuilder<MDetailsCart> builder)
        {
            builder.ToTable("DetailCart");
            builder.HasKey(d => d.IdDetailCart);
            builder.Property(d => d.IdCart).HasMaxLength(100).IsRequired();
            builder.Property(d => d.Date_Now).HasMaxLength(100).IsRequired();
            builder.Property(d => d.Hour_Now).HasMaxLength(100).IsRequired();
            builder.Property(d => d.Subtotal).HasMaxLength(100).IsRequired();
            builder.Property(d => d.Subtotal12).HasMaxLength(100).IsRequired();
            builder.Property(d => d.SubTotal0).HasMaxLength(100).IsRequired();
            builder.Property(d => d.IvaTotal).HasMaxLength(100).IsRequired();
            builder.Property(d => d.Total).HasMaxLength(100).IsRequired();
            builder.HasOne(d => d.Cart).WithMany(d => d.DetailsCart).HasForeignKey(d => d.IdCart);
        }
    }
}
