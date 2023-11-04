using ExamPortalApp.Contracts.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamPortalApp.Data.EntityConfigurations
{
    internal class AnswerConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.HasIndex(e => e.AnswerId, "IX_Answers_AnswerId");

            builder.HasIndex(e => new { e.AnswerId, e.QuestionId }, "IX_Answers_AnswerId_QuestionId").IsUnique();

            builder.HasIndex(e => e.QuestionId, "IX_Answers_QuestionId");

            builder.HasIndex(e => new { e.QuestionId, e.AnswerId, e.AnswerDesc, e.OptionCode }, "IX_Answers_QuestionId_AnswerId_AnswerDesc_OptionCode");

            builder.Property(e => e.AnswerDesc).HasMaxLength(250);
            builder.Property(e => e.OptionCode).HasMaxLength(10);

            builder.HasOne(d => d.Question).WithMany(p => p.Answers)
                .HasForeignKey(d => d.QuestionId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Answers_Questions");
        }
    }
}
