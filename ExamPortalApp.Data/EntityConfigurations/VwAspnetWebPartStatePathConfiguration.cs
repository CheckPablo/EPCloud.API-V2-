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
    internal class VwAspnetWebPartStatePathConfiguration : IEntityTypeConfiguration<VwAspnetWebPartStatePath>
    {
        public void Configure(EntityTypeBuilder<VwAspnetWebPartStatePath> builder)
        {
            builder
                  .HasNoKey()
                  .ToView("vw_aspnet_WebPartState_Paths");

            builder.Property(e => e.LoweredPath).HasMaxLength(256);
            builder.Property(e => e.Path).HasMaxLength(256);
        }
    }
}
