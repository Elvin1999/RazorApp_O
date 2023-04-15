using Microsoft.EntityFrameworkCore;
using RazorApp.Entities;

namespace RazorApp.Model
{
    public class SchoolDbContext:DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> contextOptions)
            :base(contextOptions)
        {

        }
        public DbSet<Student> Students { get; set; }
    }
}
