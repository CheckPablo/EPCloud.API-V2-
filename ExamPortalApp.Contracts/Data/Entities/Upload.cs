using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace ExamPortalApp.Contracts.Data.Entities;

public partial class Upload : EntityBase
{
    //public string? File Upload.File { get; set; }
    public string? Path { get; set; } 
    public string? Url { get; set; }
    public int? UserId { get; set; }
    public DateTime UploadDate { get; set; }
    public string File { get; set; }
    public string Name { get; set; }
}
    