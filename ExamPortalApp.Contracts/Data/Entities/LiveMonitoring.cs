using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPortalApp.Contracts.Data.Entities;

public partial class LiveMonitoring
{
    public int? StudentID { get; set; }
    public int? TestID { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? TestName { get; set; }
    public bool? Offline { get; set; }
    public DateTime? StartDate { get; set; }
    public string StudentExtraTime { get; set;}
    public DateTime? EndDate { get; set; }
    public bool? KeyPress { get; set; }
    public bool? LeftExamArea { get; set; }
    public int? Offline2 { get; set; }
    public DateTime? LastSaved { get; set; }
    public bool? FullScreenClosed { get; set; }
    public bool? IsIrregularity { get; set; }
}