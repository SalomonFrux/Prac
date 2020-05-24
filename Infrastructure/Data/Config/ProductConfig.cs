using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            //This is where we set the required properties using fluent apis
            builder.Property(p=> p.Name).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(180);
            builder.Property(p=> p.Price).HasColumnType("decimal(18, 2)");
            builder.Property(p=> p.PictureUrl).IsRequired();
            builder.HasOne(pb => pb.ProductBrand)
            .WithMany().HasForeignKey(p=>p.ProductBrandId);
            builder.HasOne(pt=>pt.ProductType).WithMany().HasForeignKey(p=>p.ProductTypeId);
        }
    }
}