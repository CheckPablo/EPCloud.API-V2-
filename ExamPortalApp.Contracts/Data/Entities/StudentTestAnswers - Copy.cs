using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPortalApp.Contracts.Data.Entities
{
    public partial class StudentTestAnswers
    {
        public int? StudentId { get; set; }
        public int? TestID { get; set; }
        public string? TestName { get; set; }
        public string? tts { get; set; }
        public string? ElectronicReader { get; set; }
        public string? Accomodation { get; set; }
        public string? TestDuration { get; set; }
        public string? StudentExtraTime { get; set; }
        public string? EndDate { get; set; }
        public string? WorkOffline { get; set; }
        public string? ScanAvailable { get; set; }
        public string? StudentName { get; set; }
        public string? Grade { get; set; }
        public string? Subject { get; set; }
        public byte[]? Data { get; set; }
        public int? QuestionPageCount { get; set; }


    }
}

