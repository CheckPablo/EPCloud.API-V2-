using ExamPortalApp.Contracts.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPortalApp.Data.EntityConfigurations
{
    internal class AspnetSchemaVersionConfiguration : IEntityTypeConfiguration<AspnetSchemaVersion>
    {
        public void Configure(EntityTypeBuilder<AspnetSchemaVersion> builder)
        {
            builder.HasKey(e => new { e.Feature, e.CompatibleSchemaVersion }).HasName("PK__aspnet_S__5A1E6BC1BD356993");

            builder.ToTable("aspnet_SchemaVersions");

            builder.Property(e => e.Feature).HasMaxLength(128);
            builder.Property(e => e.CompatibleSchemaVersion).HasMaxLength(128);
        }
    }
}
