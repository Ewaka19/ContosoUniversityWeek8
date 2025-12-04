using ContosoUniversity.Data;
using ContosoUniversity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Runtime.InteropServices;

namespace ContosoUniversity.Pages
{
    public class DisplayDevAsModel : PageModel
    {

        private readonly IConfiguration Configuration;
        private readonly SchoolContext _context;
        public string devloglevel;
        public string sqlName;
        public string sqlEnrollmentDate;

        public DisplayDevAsModel(IConfiguration configuration, SchoolContext schoolContext)
        {
            Configuration = configuration;
            _context = schoolContext;
        }
        public async Task OnGetAsync()
        {
            var loglevel = Configuration["Logging:LogLevel:Default"];
            devloglevel = $"Current default log level is: {loglevel}";

            /*
            var student = await _context.Students.SingleAsync(s => s.LastName == "Alonso");
            student.EnrollmentDate = new DateTime(2013, 10, 27);

            await _context.Database.ExecuteSqlRawAsync(
                "UPDATE dbo.Student SET FirstMidName = 'Kelly' WHERE Lastname = 'Alonso'");

            var saved = false;
            while (!saved)
            {
                try
                {
                    await _context.SaveChangesAsync();
                    saved = true;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    foreach (var entry in ex.Entries)
                    {
                        if (entry.Entity is Student)
                        {
                            var proposedValues = entry.CurrentValues;
                            var databaseValues = await entry.GetDatabaseValuesAsync();

                            proposedValues["FirstMidName"] = entry.CurrentValues["FirstMidName"];
                            proposedValues["EnrollmentDate"] = entry.CurrentValues["EnrollmentDate"];

                            entry.OriginalValues.SetValues(databaseValues);
                        }
                        else
                        {
                            throw new NotSupportedException("Don't know how to handle concurrency conflicts for " + entry.Metadata.Name);
                        }
                    }
                }
            }

            var studentLastName = "Alonso";
            var result = await _context.Students.FromSql($"EXECUTE dbo.DisplayStudentFromLastName {studentLastName}").ToListAsync();

            sqlName = result[0].FirstMidName + " " + result[0].LastName;
            sqlEnrollmentDate = result[0].EnrollmentDate.ToString();
            */
            
        }
    }
}
