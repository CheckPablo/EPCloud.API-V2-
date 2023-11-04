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
    //internal class AStudentTestConfiguration : IEntityTypeConfiguration<AStudentTest>
    //{
    //    public void Configure(EntityTypeBuilder<AStudentTest> builder)
    //    {

    //       builder.HasKey(e => new { e.StudentId, e.TestId });

    //       builder.ToTable("aStudentTest");

    //       builder.HasIndex(e => e.Absent, "Absent").HasFillFactor(90);

    //       builder.HasIndex(e => e.EndDate, "EndDate").HasFillFactor(90);

    //       builder.HasIndex(e => e.Loginguid, "NonClusteredIndex-20210810-164742");

    //       builder.HasIndex(e => e.Removed, "Removed").HasFillFactor(90);

    //       builder.HasIndex(e => e.StartDate, "StartDate").HasFillFactor(90);

    //       builder.HasIndex(e => e.StudentId, "StudentID").HasFillFactor(90);

    //       builder.HasIndex(e => e.TestId, "TestID").HasFillFactor(90);

    //       builder.HasIndex(e => e.StudentTestId, "UQ__aStudent__5B8803978B1A3C0C").IsUnique();

    //       builder.HasIndex(e => new { e.StudentId, e.TestId, e.StudentTestId }, "_dta_index_aStudentTest_18_1154103152__K2_K3_K1").HasFillFactor(90);

    //       builder.Property(e => e.StudentId).HasColumnName("StudentID");
    //       builder.Property(e => e.TestId).HasColumnName("TestID");
    //       builder.Property(e => e.EndDate).HasColumnType("datetime");
    //       builder.Property(e => e.Loginguid)
    //            .HasMaxLength(128)
    //            .HasColumnName("LOGINGUID");
    //       builder.Property(e => e.ModifiedDate).HasColumnType("datetime");
    //       builder.Property(e => e.StartDate).HasColumnType("datetime");
    //       builder.Property(e => e.StudentExtraTime)
    //            .HasMaxLength(50)
    //            .IsUnicode(false);
    //       builder.Property(e => e.StudentTestId)
    //            .ValueGeneratedOnAdd()
    //            .HasColumnName("StudentTestID");
    //    }
    //}
}
