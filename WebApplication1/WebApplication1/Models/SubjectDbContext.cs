using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class SubjectDbContext : DbContext
    {
        public SubjectDbContext(DbContextOptions<SubjectDbContext> options) : base(options) 
        {

        }

        public DbSet<Subject> Subjects { get; set;}

    }
}
