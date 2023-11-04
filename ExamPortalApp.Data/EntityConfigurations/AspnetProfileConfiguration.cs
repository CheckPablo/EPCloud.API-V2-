using ExamPortalApp.Contracts.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPortalApp.Data.builderConfigurations
{
    internal class AspnetProfileConfiguration : IEntityTypeConfiguration<AspnetProfile>
    {
       public void Configure(EntityTypeBuilder<AspnetProfile> builder)
        {
            builder.HasKey(e => e.UserId).HasName("PK__aspnet_P__1788CC4CAF9D5AE4");

            builder.ToTable("aspnet_Profile");

            builder.Property(e => e.UserId).ValueGeneratedNever();
            builder.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
            builder.Property(e => e.PropertyNames).HasColumnType("ntext");
            builder.Property(e => e.PropertyValuesBinary).HasColumnType("image");
            builder.Property(e => e.PropertyValuesString).HasColumnType("ntext");

            builder.HasOne(d => d.User).WithOne(p => p.AspnetProfile)
                .HasForeignKey<AspnetProfile>(d => d.UserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__aspnet_Pr__UserI__21D600EE");
        }
    }
}
