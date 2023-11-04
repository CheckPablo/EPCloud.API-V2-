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
    internal class VwAspnetUsersInRoleConfiguration : IEntityTypeConfiguration<VwAspnetUsersInRole>
    {
        public void Configure(EntityTypeBuilder<VwAspnetUsersInRole> builder)
        {
            builder.HasNoKey()
                   .ToView("vw_aspnet_UsersInRoles");
        }
    }
}
