using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SugarShack.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShack.Infrastructure.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(t => t.Name)
                .HasMaxLength(200)
                .IsRequired();
            builder.Property(t => t.Type)
                .IsRequired();
            builder.Property(t => t.Price)
              .IsRequired();
        }
    }
}
