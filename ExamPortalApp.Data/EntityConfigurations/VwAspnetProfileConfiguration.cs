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
    internal class VwAspnetProfileConfiguration : IEntityTypeConfiguration<VwAspnetProfile>
    {
        public void Configure(EntityTypeBuilder<VwAspnetProfile> builder)
        {
            builder
                    .HasNoKey()
                    .ToView("vw_aspnet_Profiles");
            builder.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
        }
    }
}
