using ExamPortalApp.Contracts.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamPortalApp.Data.EntityConfigurations
{
    internal class AnswerTextConfiguration : IEntityTypeConfiguration<AnswerText>
    {
        public void Configure(EntityTypeBuilder<AnswerText> builder)
        {
        }
    }
}
