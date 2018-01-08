using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppEFCore2.EntitiesConfiguration
{
    public class ProductDetailConfiguration : IEntityTypeConfiguration<ProductDetail>
    {
        public void Configure(EntityTypeBuilder<ProductDetail> builder)
        {
            builder.HasKey(x=> x.ProductID);
            builder.HasOne(e => e.Product).WithOne(o => o.Details).HasForeignKey<Product>(e => e.ProductID);
            builder.ToTable("Product");
        }
    }
}
