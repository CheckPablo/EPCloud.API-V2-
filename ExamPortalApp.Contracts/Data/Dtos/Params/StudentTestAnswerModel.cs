using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPortalApp.Contracts.Data.Dtos.Params
{
    public  class StudentTestAnswerModel
    {
       // public int 
        public int? StudentId { get; set; }
        public int? TestId { get; set; }
        public bool? KeyPress { get; set; }
        public string? TimeRemaining { get; set;  }
        public bool? LeftExamArea { get; set; }
        public bool? Offline { get; set; }
        public bool? FullScreenClosed { get; set; }
        public string? FileName { get; set; }
        public string? AnswerText { get; set; }
        public bool? Accomodation { get; set; }
       
    }
}
