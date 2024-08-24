using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduManage.BusinessObjects.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EduManage.BusinessObjects.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public string? GetConnectionString()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
            return configuration.GetConnectionString("eStore");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // optionsBuilder.UseNpgsql(
                //     "Host=localhost;Port=5432;Database=edumanage;Username=postgres;Password=12345");
                optionsBuilder.UseSqlServer("Server=localhost;Database=edumanage;User Id=sa;Password=12345;TrustServerCertificate=True");
            }
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Enrollment> Enrollments { get; set; }

        public virtual DbSet<Lecturer> Lecturers { get; set; }

        public virtual DbSet<LecturerCourse> LecturerCourses { get; set; }
        
        public virtual DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Primary keys
            modelBuilder.Entity<Student>().HasKey(s => s.StudentId);
            modelBuilder.Entity<Student>().Property(s => s.StudentId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Course>().HasKey(c => c.CourseId);
            modelBuilder.Entity<Course>().Property(c => c.CourseId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Enrollment>().HasKey(e => new { e.StudentId, e.CourseId });
            modelBuilder.Entity<Lecturer>().HasKey(l => l.LecturerId);
            modelBuilder.Entity<Lecturer>().Property(l => l.LecturerId).ValueGeneratedOnAdd();
            modelBuilder.Entity<LecturerCourse>().HasKey(lc => new { lc.LecturerId, lc.CourseId });
            modelBuilder.Entity<Role>().HasKey(r => r.RoleId);
            modelBuilder.Entity<Role>().Property(r => r.RoleId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Role>()
                .Property(r => r.RoleName)
                .HasConversion(
                    v => v.ToString(),
                    v => (RoleName)Enum.Parse(typeof(RoleName), v));


            // Relationships
            modelBuilder.Entity<Enrollment>()
                .HasOne<Student>(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId);

            modelBuilder.Entity<Enrollment>()
                .HasOne<Course>(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId);

            modelBuilder.Entity<LecturerCourse>()
                .HasOne(lc => lc.Lecturer)
                .WithMany(lc => lc.LecturerCourses)
                .HasForeignKey(lc => lc.LecturerId);

            modelBuilder.Entity<LecturerCourse>()
                .HasOne(lc => lc.Course)
                .WithMany(c => c.LecturerCourses)
                .HasForeignKey(lc => lc.CourseId);
            
            modelBuilder.Entity<Lecturer>()
                .HasOne(l => l.Role) 
                .WithMany(r => r.Lectures) 
                .HasForeignKey(l => l.RoleId);
        }
    }
}