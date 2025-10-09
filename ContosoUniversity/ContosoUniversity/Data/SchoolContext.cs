using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Components.Web.Virtualization;

namespace ContosoUniversity.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Student>().ToTable("Student");
        }
        public async Task<List<Student>> GetStudentsAsync()
        {
            return await Students.ToListAsync();
        }

        public async Task DeleteAllStudentsAsync()
        {
            var allStudents = await Students.ToListAsync();
            Students.RemoveRange(allStudents);
            await SaveChangesAsync();
        }

        /*public async virtual Task AddAllStudents
        {
           return await Students.OrderBy(student => student.LastName).ToListAsync();
        }*/
        public static List<Student> GetSeedingStudents()
        {
            return new List<Student>()
            {
                new Student() {LastName = "asd", FirstMidName = "agsd", EnrollmentDate = DateTime.Now},
                new Student() {LastName = "asd", FirstMidName = "agsd", EnrollmentDate = DateTime.Now},
                new Student() {LastName = "asd", FirstMidName = "agsd", EnrollmentDate = DateTime.Now}
            };
        }
    }
}