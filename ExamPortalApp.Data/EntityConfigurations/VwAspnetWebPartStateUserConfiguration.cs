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
    internal class VwAspnetWebPartStateUserConfiguration : IEntityTypeConfiguration<VwAspnetWebPartStateUser>
    {
        public void Configure(EntityTypeBuilder<VwAspnetWebPartStateUser> builder)
        {
            builder
                    .HasNoKey()
                    .ToView("vw_aspnet_WebPartState_User");

            builder.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
        }
    }
}
