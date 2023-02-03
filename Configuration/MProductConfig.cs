using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Models;

namespace Store.Configuration
{
    internal class MProductConfig : IEntityTypeConfiguration<MProduct>
    {
        public void Configure(EntityTypeBuilder<MProduct> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(p => p.IdProduct);
            builder.Property(p => p.CodeProduct).HasMaxLength(100).IsRequired();
            builder.Property(p => p.NameProduct).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Brand).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(100).IsRequired();
            builder.Property(p => p.P_Unitary).HasMaxLength(100).IsRequired();
            builder.Property(p => p.P_Total).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Image_Product).HasMaxLength(300).IsRequired();
        }
    }
}
