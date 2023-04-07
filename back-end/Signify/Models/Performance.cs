using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signify.Models
{
    public class Performance
    {
        public int Id { get; set; }

        public string RollNumber { get; set; } = string.Empty;

        public string PerformanceOfStudent { get; set; } = string.Empty;

        public string QuizName { get; set; } = string.Empty;
    }
}
