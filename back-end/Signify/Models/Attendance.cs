using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signify.Models
{
    public class Attendance
    {
        public int Id { get; set; }

        public string Date { get; set; } = string.Empty;

        public string Identity { get; set; } = string.Empty;

        public string Designation { get; set; } = string.Empty;
    }
}
