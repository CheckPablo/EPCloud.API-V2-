using ExamPortalApp.Contracts.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExamPortalApp.Data.EntityConfigurations
{
    internal class AnswerProgressTrackingConfiguration : IEntityTypeConfiguration<AnswerProgressTracking>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<AnswerProgressTracking> builder)
        {
           builder.HasIndex(e => new { e.TestId, e.StudentId });
        }
    }
}
