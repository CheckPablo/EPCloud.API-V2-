/*using ExamPortalApp.Contracts.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPortalApp.Contracts.Data.Dtos*/
using ExamPortalApp.Contracts.Data.Dtos;

namespace ExamPortalApp.Contracts.Data.Entities;

    public partial class UploadedTestDto : EntityBase
    {
        public string? FileName { get; set; }

        public byte[]? TestDocument { get; set; }
    }



