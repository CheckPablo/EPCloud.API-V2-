using ExamPortalApp.Contracts.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamPortalApp.Data.EntityConfigurations
{
    internal class SebsettingConfiguration : IEntityTypeConfiguration<SebSetting>
    {
        public void Configure(EntityTypeBuilder<SebSetting> builder)
        {
        }
    }
}
