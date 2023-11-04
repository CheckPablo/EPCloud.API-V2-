using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPortalApp.Infrastructure.Constants
{
    [Serializable]
    public class UserNotFoundException : Exception
    {
        public string StudentName { get; }

        public UserNotFoundException() { }

        public UserNotFoundException(string message)
            : base(message) { }

        public UserNotFoundException(string message, Exception inner)
            : base(message, inner) { }

        public UserNotFoundException(string message, string studentName)
            : this(message)
        {
            StudentName = studentName;
        }
    }
}
