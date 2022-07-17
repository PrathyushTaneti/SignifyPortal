using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SignifyAPI.Models
{
    public partial class SignifyDbContext : DbContext
    {
        public SignifyDbContext()
        {
        }

        public SignifyDbContext(DbContextOptions<SignifyDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EmployeeDetails> EmployeeDetails { get; set; } = null!;
        public virtual DbSet<StudentDetails> StudentDetails { get; set; } = null!;
        public virtual DbSet<ActiveMeetings> ActiveMeetings { get; set; } = null!;
        public virtual DbSet<ActivePrograms> ActivePrograms { get; set; } = null!;
        public virtual DbSet<Performance> Performance { get; set; } = null!;
        public virtual DbSet<AdminDetails> AdminDetails { get; set; } = null!;
        public virtual DbSet<AttendanceTracker> AttendanceTracker { get; set; } = null!;





        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=IRON-MAN\\SQLEXPRESS;Database=SignifyDb;Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeDetails>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Department)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProfilePicture)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Subject)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StudentDetails>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProfilePicture)
                   .HasMaxLength(500)
                   .IsUnicode(false);

                entity.Property(e => e.Course)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Department)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.GuardianName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RollNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });


            modelBuilder.Entity<ActiveMeetings>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.JoinLink)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Subject)
                   .HasMaxLength(50)
                   .IsUnicode(false);

            });

            modelBuilder.Entity<AttendanceTracker>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Identity)
                   .HasMaxLength(50)
                   .IsUnicode(false);

                entity.Property(e => e.Designation)
                   .HasMaxLength(50)
                   .IsUnicode(false);

            });

            modelBuilder.Entity<AdminDetails>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Performance>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.RollNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PerformanceOfStudent)
                   .HasMaxLength(50)
                   .IsUnicode(false);

                entity.Property(e => e.QuizName)
                   .HasMaxLength(100)
                   .IsUnicode(false);
            });

            modelBuilder.Entity<ActivePrograms>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ProgramLink)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.ProgramName)
                   .HasMaxLength(150)
                   .IsUnicode(false);

            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
