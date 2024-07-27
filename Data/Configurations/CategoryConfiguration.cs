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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnType("int");
            builder.Property(x => x.Name).HasColumnType("nvarchar").HasMaxLength(150).IsRequired();
            builder.Property(x => x.ImageUrl).HasColumnType("varchar(MAX)");
            builder.Property(x => x.Slug).HasColumnType("varchar").HasMaxLength(150).IsRequired();
            builder.Property(x => x.ParentId).HasColumnType("int");
            builder.ConfigurationAuditable();
        }
    }
}
