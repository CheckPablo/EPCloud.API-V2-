using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPortalApp.Contracts.Data.Dtos.Params
{
    public class ScannedImagesOTP
    {
        public int OTP { get; set; }
        public int StudentId { get; set; }

        public int TestId { get; set; }

    }
}
