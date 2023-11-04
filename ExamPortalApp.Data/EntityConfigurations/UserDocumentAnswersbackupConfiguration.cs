using ExamPortalApp.Contracts.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamPortalApp.Data.EntityConfigurations
{
    internal class UserDocumentAnswersbackupConfiguration : IEntityTypeConfiguration<UserDocumentAnswersBackup>
    {
        public void Configure(EntityTypeBuilder<UserDocumentAnswersBackup> builder)
        {
        }
    }
}
