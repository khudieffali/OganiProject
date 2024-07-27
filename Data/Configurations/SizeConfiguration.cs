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
    public class SizeConfiguration : IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnType("int");
            builder.Property(x => x.Name).HasColumnType("nvarchar").HasMaxLength(150).IsRequired();
            builder.Property(x => x.Slug).HasColumnType("varchar").HasMaxLength(150).IsRequired();
            builder.ConfigurationAuditable();
        }
    }
}
