using ExamPortalApp.Contracts.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamPortalApp.Data.EntityConfigurations
{
    internal class AspnetPersonalizationAllUserConfiguration : IEntityTypeConfiguration<AspnetPersonalizationAllUser>
    {
        public void Configure(EntityTypeBuilder<AspnetPersonalizationAllUser> builder)
        {
            builder.HasKey(e => e.PathId).HasName("PK__aspnet_P__CD67DC59EDC10811");

            builder.ToTable("aspnet_PersonalizationAllUsers");

            builder.Property(e => e.PathId).ValueGeneratedNever();
            builder.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
            builder.Property(e => e.PageSettings).HasColumnType("image");

            builder.HasOne(d => d.Path).WithOne(p => p.AspnetPersonalizationAllUser)
                 .HasForeignKey<AspnetPersonalizationAllUser>(d => d.PathId)
                 .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
