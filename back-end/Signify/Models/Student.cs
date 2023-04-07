using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signify.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string MobileNumber { get; set; } = string.Empty;

        public string Gender { get; set; } = string.Empty;

        public string Course { get; set; } = string.Empty;

        public string Department { get; set; } = string.Empty;

        public string RollNumber { get; set; } = string.Empty;

        public string GuardianName { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string ProfilePicture { get; set; } = string.Empty;
    }
}
