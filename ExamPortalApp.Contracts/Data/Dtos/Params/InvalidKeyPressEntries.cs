using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPortalApp.Contracts.Data.Dtos.Params
{
    public class InvalidKeyPressEntries
    {
        public string? Event { get; set; }

        public string? Reason { get; set; }

        //public DateTime? DateModified { get; set; }

        public int? StudentId { get; set; }

        public int? TestId { get; set; }

    }
}
