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
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnType("int");
            builder.Property(x => x.Title).HasColumnType("nvarchar").HasMaxLength(150).IsRequired();
            builder.Property(x => x.ImageUrl).HasColumnType("varchar(MAX)").IsRequired();
            builder.Property(x => x.Description).HasColumnType("varchar(MAX)");
            builder.HasOne(x=>x.BlogCategory).WithMany(y=>y.Blogs).HasForeignKey(x=>x.BlogCategoryId).HasPrincipalKey(x=>x.Id).OnDelete(DeleteBehavior.NoAction);
            builder.ConfigurationAuditable();
        }
    }
}
