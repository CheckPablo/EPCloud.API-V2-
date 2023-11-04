using System;
using System.Collections.Generic;

namespace ExamPortalApp.Contracts.Data.Entities;

public partial class AspnetSchemaVersion
{
    public string Feature { get; set; } = null!;

    public string CompatibleSchemaVersion { get; set; } = null!;

    public bool IsCurrentVersion { get; set; }
}
