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
    internal class AspnetPathConfiguration : IEntityTypeConfiguration<AspnetPath>
    {
        public void Configure(EntityTypeBuilder<AspnetPath> builder)
        {
           builder.HasKey(e => e.PathId)
                     .HasName("PK__aspnet_P__CD67DC58395E0EF9")
                     .IsClustered(false);

           builder.ToTable("aspnet_Paths");

           builder.HasIndex(e => new { e.ApplicationId, e.LoweredPath }, "aspnet_Paths_index")
                .IsUnique()
                .IsClustered()
                .HasFillFactor(90);

           builder.Property(e => e.PathId).HasDefaultValueSql("(newid())");
           builder.Property(e => e.LoweredPath).HasMaxLength(256);
           builder.Property(e => e.Path).HasMaxLength(256);

           builder.HasOne(d => d.Application).WithMany(p => p.AspnetPaths)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__aspnet_Pa__Appli__1A34DF26");
        }
    }
}
