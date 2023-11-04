using ExamPortalApp.Contracts.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamPortalApp.Data.EntityConfigurations
{
    internal class StimuluseCnfiguration : IEntityTypeConfiguration<Stimulus>
    {
        public void Configure(EntityTypeBuilder<Stimulus> builder)
        {

        }
    }
}
