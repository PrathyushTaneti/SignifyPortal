using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signify.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Gender { get; set; } = string.Empty;

        public string MobileNumber { get; set; } = string.Empty;

        public string Department { get; set; } = string.Empty;

        public string EmailAddress { get; set; } = string.Empty;

        public string Subject { get; set; } = string.Empty;

        public string ProfilePicture { get; set; } = string.Empty;
    }
}
