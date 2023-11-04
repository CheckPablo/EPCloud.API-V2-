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
    internal class TestCategoryConfiguration : IEntityTypeConfiguration<TestCategory>
    {
        public void Configure(EntityTypeBuilder<TestCategory> builder)
        {
        }
    }
}
