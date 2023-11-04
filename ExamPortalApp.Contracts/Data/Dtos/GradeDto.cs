using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPortalApp.Contracts.Data.Dtos
{
    public class GradeDto
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty; 
        public string Description { get; set; }= string.Empty;
    }
}
