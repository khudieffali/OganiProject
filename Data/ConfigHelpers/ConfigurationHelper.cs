using Infrastructure.Commons.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Helpers
{
    public static class ConfigurationHelper
    {
        public static EntityTypeBuilder<T> ConfigurationAuditable<T>(this EntityTypeBuilder<T> builder) where T: AuditableEntity
        {
            builder.Property(a => a.CreatedBy).HasColumnType("int").IsRequired();
            builder.Property(a => a.CreatedAt).HasColumnType("datetime").IsRequired();
            builder.Property(a => a.UpdatedBy).HasColumnType("int");
            builder.Property(a => a.UpdatedAt).HasColumnType("datetime");
            builder.Property(a => a.DeletedBy).HasColumnType("int");
            builder.Property(a => a.DeletedAt).HasColumnType("datetime");
            return builder;
        }
    }
}
