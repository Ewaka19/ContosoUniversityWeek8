using ContosoUniversity.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Data
{
    public class InstructorContext : DbContext
    {
        public InstructorContext(DbContextOptions<InstructorContext> options) : base(options) { }

        public DbSet<Instructor> Instructors => Set<Instructor>();
    }
}
