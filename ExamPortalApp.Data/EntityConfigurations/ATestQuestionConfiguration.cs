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
    //internal class ATestQuestionConfiguration : IEntityTypeConfiguration<ATestQuestion>
    //{
    //    public void Configure(EntityTypeBuilder<ATestQuestion> builder)
    //    {
    //       builder.HasKey(e => new { e.TestId, e.QuestionId });

    //       builder.ToTable("aTestQuestion");

    //       builder.HasIndex(e => e.QuestionId, "QuestionID").HasFillFactor(90);

    //       builder.HasIndex(e => e.QuestionNo, "QuestionNo").HasFillFactor(90);

    //       builder.HasIndex(e => e.Removed, "Removed").HasFillFactor(90);

    //       builder.HasIndex(e => e.TestId, "TestID").HasFillFactor(90);

    //       builder.HasIndex(e => e.TestQuestionId, "UQ__aTestQue__4C589E680A2842C2").IsUnique();

    //       builder.HasIndex(e => new { e.TestId, e.QuestionNo, e.QuestionId }, "_dta_index_aTestQuestion_18_1186103266__K2_K4_K3").HasFillFactor(90);

    //       builder.HasIndex(e => new { e.QuestionId, e.TestId }, "_dta_index_aTestQuestion_18_1186103266__K3_K2").HasFillFactor(90);

    //       builder.Property(e => e.TestId).HasColumnName("TestID");
    //       builder.Property(e => e.QuestionId).HasColumnName("QuestionID");
    //       builder.Property(e => e.ModifiedDate).HasColumnType("datetime");
    //       builder.Property(e => e.TestQuestionId)
    //            .ValueGeneratedOnAdd()
    //            .HasColumnName("TestQuestionID");
    //    }
    //}
}
