using ContosoUniversity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace ContosoUniversityUnitTest.Utilities
{
    public class Utilities
    {
        public static DbContextOptions<SchoolContext> TestDbContextOptions()
        {
            var serviceProvider = new ServiceCollection().AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<SchoolContext>().UseInMemoryDatabase("InMemoryDb").UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }
    }
}
