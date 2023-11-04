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
    internal class AspnetMembershipConfiguration : IEntityTypeConfiguration<AspnetMembership>
    {
        public void Configure(EntityTypeBuilder<AspnetMembership> builder)
        {
           builder.HasKey(e => e.UserId)
                    .HasName("PK__aspnet_M__1788CC4DCD837534")
                    .IsClustered(false);

           builder.ToTable("aspnet_Membership");

           builder.Property(e => e.UserId).ValueGeneratedNever();
           builder.Property(e => e.Comment).HasColumnType("ntext");
           builder.Property(e => e.CreateDate).HasColumnType("datetime");
           builder.Property(e => e.Email).HasMaxLength(256);
           builder.Property(e => e.FailedPasswordAnswerAttemptWindowStart).HasColumnType("datetime");
           builder.Property(e => e.FailedPasswordAttemptWindowStart).HasColumnType("datetime");
           builder.Property(e => e.LastLockoutDate).HasColumnType("datetime");
           builder.Property(e => e.LastLoginDate).HasColumnType("datetime");
           builder.Property(e => e.LastPasswordChangedDate).HasColumnType("datetime");
           builder.Property(e => e.LoweredEmail).HasMaxLength(256);
           builder.Property(e => e.MobilePin)
                .HasMaxLength(16)
                .HasColumnName("MobilePIN");
           builder.Property(e => e.Password).HasMaxLength(128);
           builder.Property(e => e.PasswordAnswer).HasMaxLength(128);
           builder.Property(e => e.PasswordSalt).HasMaxLength(128);

           builder.HasOne(d => d.Application).WithMany(p => p.AspnetMemberships)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__aspnet_Me__Appli__1387E197");

           builder.HasOne(d => d.User).WithOne(p => p.AspnetMembership)
                .HasForeignKey<AspnetMembership>(d => d.UserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__aspnet_Me__UserI__1293BD5E");
        }
    }
}
