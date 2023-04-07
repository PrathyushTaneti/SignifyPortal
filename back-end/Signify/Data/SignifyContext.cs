using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Signify.Models;

namespace Signify.Data
{
    public class SignifyContext : DbContext
    {
        public SignifyContext (DbContextOptions<SignifyContext> options)
            : base(options)
        {
        }

        public DbSet<Signify.Models.Admin> Admin { get; set; } 

        public DbSet<Signify.Models.Assignment> Assignment { get; set; } = default!;

        public DbSet<Signify.Models.Attendance> Attendance { get; set; } = default!;

        public DbSet<Signify.Models.Employee> Employee { get; set; } = default!;

        public DbSet<Signify.Models.Meeting> Meeting { get; set; } = default!;

        public DbSet<Signify.Models.Student> Student { get; set; } = default!;

        public DbSet<Signify.Models.Performance> Performance { get; set; } = default!;
    }
}
