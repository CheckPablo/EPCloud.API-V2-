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
    internal class AspnetUserConfiguration : IEntityTypeConfiguration<AspnetUser>
    {
        public void Configure(EntityTypeBuilder<AspnetUser> builder)
        {
            builder.HasKey(e => e.UserId)
                   .HasName("PK__aspnet_U__1788CC4DDBEBEFD3")
                   .IsClustered(false);

            builder.ToTable("aspnet_Users");

            builder.HasIndex(e => new { e.ApplicationId, e.LoweredUserName }, "aspnet_Users_Index")
                .IsUnique()
                .IsClustered()
                .HasFillFactor(90);

            builder.HasIndex(e => new { e.ApplicationId, e.LastActivityDate }, "aspnet_Users_Index2").HasFillFactor(90);

            builder.Property(e => e.UserId).HasDefaultValueSql("(newid())");
            builder.Property(e => e.LastActivityDate).HasColumnType("datetime");
            builder.Property(e => e.LoweredUserName).HasMaxLength(256);
            builder.Property(e => e.MobileAlias).HasMaxLength(16);
            builder.Property(e => e.UserName).HasMaxLength(256);

            builder.HasOne(d => d.Application).WithMany(p => p.AspnetUsers)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__aspnet_Us__Appli__25A691D2");

            builder.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspnetUsersInRole",
                    r => r.HasOne<AspnetRole>().WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("FK__aspnet_Us__RoleI__278EDA44"),
                    l => l.HasOne<AspnetUser>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("FK__aspnet_Us__UserI__2882FE7D"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId").HasName("PK__aspnet_U__AF2760AD5F7251C8");
                        j.ToTable("aspnet_UsersInRoles");
                        j.HasIndex(new[] { "RoleId" }, "aspnet_UsersInRoles_index").HasFillFactor(90);
                    });
        }
    }
}
