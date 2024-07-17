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
    public class PictureConfiguration : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnType("int");
            builder.Property(x => x.ImageUrl).HasColumnType("varchar(MAX)");
            builder.Property(x => x.IsMain).HasColumnType("bit");
            builder.HasOne(x=>x.Product).WithMany(y=>y.ProductPictures).HasForeignKey(x => x.ProductId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.NoAction);
            builder.ConfigurationAuditable();

        }
    }
}
