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
    internal class KeyPressTrackingConfiguration : IEntityTypeConfiguration<KeyPressTracking>
    {
        public void Configure(EntityTypeBuilder<KeyPressTracking> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__KeyPress__3214EC27FA7E5C6F");

            builder.HasIndex(e => new { e.StudentId, e.TestId }, "IDXStudent_TestID");

            builder.Property(e => e.Id).HasColumnName("ID");
            builder.Property(e => e.DateModified).HasColumnType("datetime");
            builder.Property(e => e.Event)
                .HasMaxLength(1000)
                .IsUnicode(false);
            builder.Property(e => e.Reason).IsUnicode(false);
            builder.Property(e => e.StudentId).HasColumnName("StudentID");
            builder.Property(e => e.TestId).HasColumnName("TestID");
        }
    }
}
