using System;
using System.Collections.Generic;

namespace ExamPortalApp.Contracts.Data.Entities;

public partial class Role
{
    public short Id { get; set; }

    public string RoleName { get; set; } = null!;

    public string RoleDescription { get; set; } = null!;

    public virtual ICollection<UserRole> UserRoles { get; } = new List<UserRole>();
}
