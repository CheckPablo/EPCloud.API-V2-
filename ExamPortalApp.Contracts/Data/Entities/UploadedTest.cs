using System;
using System.Collections.Generic;

namespace ExamPortalApp.Contracts.Data.Entities;

public partial class UploadedTest : EntityBase
{
    public string? FileName { get; set; }

    public byte[]? TestDocument { get; set; }
}
