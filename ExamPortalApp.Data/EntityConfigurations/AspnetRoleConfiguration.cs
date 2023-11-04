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
    internal class AspnetRoleConfiguration : IEntityTypeConfiguration<AspnetRole>
    {
        public void Configure(EntityTypeBuilder<AspnetRole> builder)
        {
            builder.HasKey(e => e.RoleId)
                    .HasName("PK__aspnet_R__8AFACE1BE0E47F96")
                    .IsClustered(false);

                builder.ToTable("aspnet_Roles");

                builder.HasIndex(e => new { e.ApplicationId, e.LoweredRoleName }, "aspnet_Roles_index1")
                    .IsUnique()
                    .IsClustered()
                    .HasFillFactor(90);

                builder.Property(e => e.RoleId).HasDefaultValueSql("(newid())");
                builder.Property(e => e.Description).HasMaxLength(256);
                builder.Property(e => e.LoweredRoleName).HasMaxLength(256);
                builder.Property(e => e.RoleName).HasMaxLength(256);

                builder.HasOne(d => d.Application).WithMany(p => p.AspnetRoles)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__aspnet_Ro__Appli__23BE4960");
        }
    }
}
