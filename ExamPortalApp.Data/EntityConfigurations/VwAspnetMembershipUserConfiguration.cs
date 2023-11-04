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
    internal class VwAspnetMembershipUserConfiguration : IEntityTypeConfiguration<VwAspnetMembershipUser>
    {
        public void Configure(EntityTypeBuilder<VwAspnetMembershipUser> builder)
        {
            builder    .HasNoKey()
                       .ToView("vw_aspnet_MembershipUsers");

            builder.Property(e => e.Comment).HasColumnType("ntext");
            builder.Property(e => e.CreateDate).HasColumnType("datetime");
            builder.Property(e => e.Email).HasMaxLength(256);
            builder.Property(e => e.FailedPasswordAnswerAttemptWindowStart).HasColumnType("datetime");
            builder.Property(e => e.FailedPasswordAttemptWindowStart).HasColumnType("datetime");
            builder.Property(e => e.LastActivityDate).HasColumnType("datetime");
            builder.Property(e => e.LastLockoutDate).HasColumnType("datetime");
            builder.Property(e => e.LastLoginDate).HasColumnType("datetime");
            builder.Property(e => e.LastPasswordChangedDate).HasColumnType("datetime");
            builder.Property(e => e.LoweredEmail).HasMaxLength(256);
            builder.Property(e => e.MobileAlias).HasMaxLength(16);
            builder.Property(e => e.MobilePin)
                .HasMaxLength(16)
                .HasColumnName("MobilePIN");
            builder.Property(e => e.PasswordAnswer).HasMaxLength(128);
            builder.Property(e => e.UserName).HasMaxLength(256);
        }
    }
}
