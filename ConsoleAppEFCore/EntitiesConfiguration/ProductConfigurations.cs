using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleAppEFCore2.EntitiesConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.ProductID);

            builder.HasOne(e => e.Details).WithOne( o=> o.Product).HasForeignKey<ProductDetail>(e => e.ProductID);
            builder.Property(x => x.Cost).HasColumnName("StandardCost");
            builder.HasQueryFilter(o => o.Cost > 0);
            builder.ToTable("Product");

        }
    }
}
