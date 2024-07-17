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
    public class OrganicConfiguration : IEntityTypeConfiguration<Organic>
    {
        public void Configure(EntityTypeBuilder<Organic> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnType("int");
            builder.Property(x => x.Title).HasColumnType("nvarchar").HasMaxLength(350).IsRequired();
            builder.Property(x => x.SubTitle).HasColumnType("nvarchar").HasMaxLength(350);
            builder.Property(x => x.Description).HasColumnType("nvarchar(MAX)");
            builder.Property(x => x.ImageUrl).HasColumnType("varchar(MAX)").IsRequired();
            builder.Property(x => x.IsMain).HasColumnType("bit");
            builder.ConfigurationAuditable();

        }
    }
}
