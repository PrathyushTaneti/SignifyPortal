using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signify.Models
{
    internal class Meetings
    {
        public int Id { get; set; }

        public string JoinLink { get; set; } = string.Empty;

        public string Subject { get; set; } = string.Empty;
    }
}
