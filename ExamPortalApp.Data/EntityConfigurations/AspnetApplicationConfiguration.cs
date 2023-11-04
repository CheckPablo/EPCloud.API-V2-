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
    internal class AspnetApplicationConfiguration : IEntityTypeConfiguration<AspnetApplication>
    {
        public void Configure(EntityTypeBuilder<AspnetApplication> builder)
        {
           builder.HasKey(e => e.ApplicationId)
                   .HasName("PK__aspnet_A__C93A4C98CED8A85C")
                   .IsClustered(false);

           builder.ToTable("aspnet_Applications");

           builder.HasIndex(e => e.LoweredApplicationName, "UQ__aspnet_A__17477DE43F4045CA").IsUnique();

           builder.HasIndex(e => e.ApplicationName, "UQ__aspnet_A__3091033139F4CAB8").IsUnique();

           builder.HasIndex(e => e.LoweredApplicationName, "aspnet_Applications_Index")
                .IsClustered()
                .HasFillFactor(90);

           builder.Property(e => e.ApplicationId).HasDefaultValueSql("(newid())");
           builder.Property(e => e.ApplicationName).HasMaxLength(256);
           builder.Property(e => e.Description).HasMaxLength(256);
           builder.Property(e => e.LoweredApplicationName).HasMaxLength(256);
        }
    }
}
