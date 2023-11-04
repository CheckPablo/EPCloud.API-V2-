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
    internal class BckaStimulusTextConfiguration : IEntityTypeConfiguration<BckaStimulusText>
    {
        public void Configure(EntityTypeBuilder<BckaStimulusText> builder)
        {
            builder.HasNoKey()
                     .ToTable("bckaStimulusText");

            builder.Property(e => e.ModifiedDate).HasColumnType("datetime");
            builder.Property(e => e.StimulusId).HasColumnName("StimulusID");
            builder.Property(e => e.StimulusText).IsUnicode(false);
            builder.Property(e => e.StimulusTextId)
                .ValueGeneratedOnAdd()
                .HasColumnName("StimulusTextID");
        }
    }
}
