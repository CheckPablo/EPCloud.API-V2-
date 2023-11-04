using ExamPortalApp.Contracts.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamPortalApp.Data.EntityConfigurations
{
    internal class StimulusImageConfiguration : IEntityTypeConfiguration<StimulusImage>
    {
        public void Configure(EntityTypeBuilder<StimulusImage> builder)
        {
        }
    }
}
