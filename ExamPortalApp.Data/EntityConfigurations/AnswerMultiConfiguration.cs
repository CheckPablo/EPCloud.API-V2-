using ExamPortalApp.Contracts.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamPortalApp.Data.EntityConfigurations
{
    internal class AnswerMultiConfiguration : IEntityTypeConfiguration<AnswerMultiple>
    {
        public void Configure(EntityTypeBuilder<AnswerMultiple> builder)
        {
        }
    }
}
