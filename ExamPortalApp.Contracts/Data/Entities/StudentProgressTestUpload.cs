using System;
using System.Collections.Generic;

namespace ExamPortalApp.Contracts.Data.Entities;

public partial class StudentProgressTestUpload
{
    public int Id { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public bool? IsAbsent { get; set; }

    public string? TimeRemaining { get; set; }

    public bool? ElectronicReader { get; set; }

    public bool? Accomodation { get; set; }

    public string? StudentExtraTime { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? StudentId { get; set; }

    public int? TestId { get; set; }
}
