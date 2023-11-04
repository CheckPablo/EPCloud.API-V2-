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
    internal class BufferATestQuestionConfiguration : IEntityTypeConfiguration<BufferATestQuestion>
    {
        public void Configure(EntityTypeBuilder<BufferATestQuestion> builder)
        {

            builder
                .HasNoKey()
                .ToTable("buffer_aTestQuestion");

            builder.Property(e => e.ModifiedDate).HasColumnType("datetime");
            builder.Property(e => e.QuestionId).HasColumnName("QuestionID");
            builder.Property(e => e.TestId).HasColumnName("TestID");
            builder.Property(e => e.TestQuestionId)
                .ValueGeneratedOnAdd()
                .HasColumnName("TestQuestionID");
        }
    }
}
