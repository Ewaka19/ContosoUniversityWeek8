using ContosoUniversity.Data;
using ContosoUniversity.Models;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace ContosoUniversityUnitTest.UnitTests
{
    public class Create_DataAccessLayerTest
    {
        [Fact]
        public async Task GetStudentsAsync_StudentsAreReturned()
        {
            using (var db = new SchoolContext(Utilities.Utilities.TestDbContextOptions()))
            {
                // Arrange
                var expectedStudents = SchoolContext.GetSeedingStudents();
                await db.AddRangeAsync(expectedStudents);
                await db.SaveChangesAsync();

                // Act
                var result = await db.GetStudentsAsync();

                // Assert
                var actualStudents = Assert.IsAssignableFrom<List<Student>>(result);
                Assert.Equal(
                    expectedStudents.OrderBy(m => m.ID).Select(m => m.LastName),
                    expectedStudents.OrderBy(m => m.ID).Select(m => m.LastName));
            }
        }

        [Fact]
        public async Task DeleteAllStudentsAsync_StudentsAreDeleted()
        {
            using (var db = new SchoolContext(Utilities.Utilities.TestDbContextOptions()))
            {
                // Arrange
                var seedStudents = SchoolContext.GetSeedingStudents();
                await db.AddRangeAsync(seedStudents);
                await db.SaveChangesAsync();

                // Act
                await db.DeleteAllStudentsAsync();

                // Assert
                Assert.Empty(await db.Students.AsNoTracking().ToListAsync());
            }
        }
    }
}
