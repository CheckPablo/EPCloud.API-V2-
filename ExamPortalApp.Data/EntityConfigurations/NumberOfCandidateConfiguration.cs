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
    internal class NumberOfCandidateConfiguration : IEntityTypeConfiguration<NumberOfCandidate>
    {
        public void Configure(EntityTypeBuilder<NumberOfCandidate> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__NumberOf__3214EC279D35C5E6");

            builder.Property(e => e.Id).HasColumnName("ID");
            builder.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
        }
    }
}
