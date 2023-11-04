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
    internal class TmpBckasnConfiguration : IEntityTypeConfiguration<TmpBckasn>
    {
        public void Configure(EntityTypeBuilder<TmpBckasn> builder)
        {
            builder
                    .HasNoKey()
                    .ToTable("tmpBCKasns");

            builder.Property(e => e.AnswerId).HasColumnName("AnswerID");
            builder.Property(e => e.ModifiedDate).HasColumnType("datetime");
            builder.Property(e => e.StudentId).HasColumnName("StudentID");
            builder.Property(e => e.StudentProgressId).HasColumnName("StudentProgressID");
            builder.Property(e => e.TestId).HasColumnName("TestID");
            builder.Property(e => e.TestQuestionId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TestQuestionID");
            builder.Property(e => e.TimeRemaining)
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(e => e.TimeStamp).HasColumnType("datetime");
        }
    }
}
