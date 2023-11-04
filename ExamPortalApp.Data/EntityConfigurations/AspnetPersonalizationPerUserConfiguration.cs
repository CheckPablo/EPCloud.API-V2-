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
    internal class AspnetPersonalizationPerUserConfiguration : IEntityTypeConfiguration<AspnetPersonalizationPerUser>
    {
        public void Configure(EntityTypeBuilder<AspnetPersonalizationPerUser> builder)
        {
           builder.HasKey(e => e.Id)
                    .HasName("PK__aspnet_P__3214EC06F3D7E7E5")
                    .IsClustered(false);

           builder.ToTable("aspnet_PersonalizationPerUser");

           builder.HasIndex(e => new { e.PathId, e.UserId }, "aspnet_PersonalizationPerUser_index1")
                .IsUnique()
                .IsClustered()
                .HasFillFactor(90);

           builder.HasIndex(e => new { e.UserId, e.PathId }, "aspnet_PersonalizationPerUser_ncindex2")
                .IsUnique()
                .HasFillFactor(90);

           builder.Property(e => e.Id).HasDefaultValueSql("(newid())");
           builder.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
           builder.Property(e => e.PageSettings).HasColumnType("image");

           builder.HasOne(d => d.Path).WithMany(p => p.AspnetPersonalizationPerUsers)
                .HasForeignKey(d => d.PathId)
                .HasConstraintName("FK__aspnet_Pe__PathI__1E05700A");

           builder.HasOne(d => d.User).WithMany(p => p.AspnetPersonalizationPerUsers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__aspnet_Pe__UserI__1EF99443");
        }
    }
}
