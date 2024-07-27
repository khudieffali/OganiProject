using Data.Helpers;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnType("int");
            builder.Property(x => x.Name).HasColumnType("nvarchar").HasMaxLength(150).IsRequired();
            builder.Property(x => x.Description).HasColumnType("nvarchar(MAX)");
            builder.Property(x => x.Price).HasColumnType("decimal").IsRequired();
            builder.Property(x => x.Discount).HasColumnType("decimal");
            builder.Property(x => x.Slug).HasColumnType("varchar").HasMaxLength(150).IsRequired();
            builder.Property(x => x.Review).HasColumnType("int");
            builder.Property(x => x.Weight).HasColumnType("nvarchar").HasMaxLength(400);
            builder.Property(x => x.Shipping).HasColumnType("nvarchar").HasMaxLength(250);
            builder.Property(x => x.IsAvailability).HasColumnType("bit");
            builder.Property(x => x.Rating).HasColumnType("float");
            builder.Property(x => x.IsFeatured).HasColumnType("bit");
            builder.Property(x => x.Rating).HasColumnType("float");
            builder.HasOne(x=>x.Category).WithMany(y=>y.Products).HasForeignKey(x => x.CategoryId).HasPrincipalKey(x=>x.Id).OnDelete(DeleteBehavior.NoAction);
            builder.ConfigurationAuditable();

        }
    }
}
