using System;
using System.Collections.Generic;

namespace ExamPortalApp.Contracts.Data.Entities;

public partial class SebSetting
{
    public int Id { get; set; }

    public string? HashDescription { get; set; }

    public string? Sebsettings { get; set; }

    public string? MacSebsettings { get; set; }
}
