using System;
using System.Collections.Generic;

namespace SignifyAPI.Models
{
    public partial class StudentDetails
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? MobileNumber { get; set; }

        public string? Gender { get; set; }

        public string? Course { get; set; }

        public string? Department { get; set; }

        public string? RollNumber { get; set; }

        public string? GuardianName { get; set; }

        public string? Address { get; set; }

        public string? ProfilePicture { get; set; }
    }
}
