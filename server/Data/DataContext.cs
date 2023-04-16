namespace server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {            
        }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<Assignment> Assignments { get; set; }

        public DbSet<Attendance> Attendances { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Meeting> Meetings { get; set; }

        public DbSet<Performance> Performances { get; set; }

        public DbSet<Student> Students { get; set; }

    }
}
