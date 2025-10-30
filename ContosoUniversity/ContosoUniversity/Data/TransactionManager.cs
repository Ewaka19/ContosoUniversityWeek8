
using ContosoUniversity.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Data
{
    public class TransactionManager
    {
        private readonly SchoolContext _context;

        public TransactionManager(SchoolContext context)
        {
            _context = context;
        }

        public async void HandleMultiEntityTransaction()
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                _context.Students.Add(new Student { FirstMidName = "Larry The", LastName = "Lobster" });
                await _context.SaveChangesAsync();

                _context.Courses.Add(new Course { Title = "Weight Lifting" });
                await _context.SaveChangesAsync();

                var students = await _context.Students.OrderBy(s => s.FirstMidName).ToListAsync();
                var courses = await _context.Courses.OrderBy(c => c.Title).ToListAsync();


            }

            catch (Exception ex)
            {

            }
        }
    }
}
