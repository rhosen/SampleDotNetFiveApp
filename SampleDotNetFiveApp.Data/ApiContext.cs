using Microsoft.EntityFrameworkCore;
using SampleDotNetFiveApp.Data.Entities;

namespace SampleDotNetFiveApp.Data
{
    public class ApiContext:DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        public DbSet<Applicant> Users { get; set; }

    }
}
