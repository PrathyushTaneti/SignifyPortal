 using System;
using System.Collections.Generic;

namespace SignifyAPI.Models
{
    public partial class EmployeeDetails
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Gender { get; set; }

        public string? MobileNumber { get; set; }

        public string? Department { get; set; }

        public string? EmailAddress { get; set; }

        public string? Subject { get; set; }

        public string? ProfilePicture { get; set; }

    }
}
