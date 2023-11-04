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
    internal class UploadedTestConfiguration : IEntityTypeConfiguration<UploadedTest>
    {
        public void Configure(EntityTypeBuilder<UploadedTest> builder)
        {
        }
    }
}
