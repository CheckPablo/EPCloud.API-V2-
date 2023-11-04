using System;
using System.Collections.Generic;

namespace ExamPortalApp.Contracts.Data.Entities;

public partial class UserRole
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? CenterId { get; set; }

    public short RoleId { get; set; }

    public int? OldUserId { get; set; }

    public int? OldCenterId { get; set; }

    public virtual Center? Center { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual User? User { get; set; }
}
