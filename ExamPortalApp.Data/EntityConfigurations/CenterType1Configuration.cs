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
    //internal class CenterType1Configuration : IEntityTypeConfiguration<CenterType1>
    //{
    //    public void Configure(EntityTypeBuilder<CenterType1> builder)
    //    {
    //        builder.HasKey(e => e.CenterTypeId).HasName("PK__lCenterT__790E764CE79327AC");

    //        builder.ToTable("CenterTypes");

    //        builder.Property(e => e.CenterTypeId).HasColumnName("CenterTypeID");
    //        builder.Property(e => e.Description)
    //            .HasMaxLength(50)
    //            .IsUnicode(false);
    //        builder.Property(e => e.ModifiedDate).HasColumnType("datetime");
    //    }
    //}
}
