using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Data.Configrations
{
    internal class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.HasOne(P => P.productBrand).WithMany().HasForeignKey(P => P.BrandId);
            builder.HasOne(P => P.productType).WithMany().HasForeignKey(P => P.TypeId);

            builder.Property(P => P.Price).HasColumnType("decimal(10,2)");

        }
    }
}
