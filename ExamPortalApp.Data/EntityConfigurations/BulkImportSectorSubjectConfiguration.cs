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
    internal class BulkImportSectorSubjectConfiguration : IEntityTypeConfiguration<BulkImportSectorSubject>
    {
        public void Configure(EntityTypeBuilder<BulkImportSectorSubject> builder)
        {
        }
    }
}
