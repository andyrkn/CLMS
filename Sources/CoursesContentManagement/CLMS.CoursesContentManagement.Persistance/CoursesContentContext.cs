using CLMS.CoursesContentManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace CLMS.CoursesContentManagement.Persistance
{
    public class CoursesContentContext : DbContext
    {
        public CoursesContentContext(DbContextOptions<CoursesContentContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<CourseContent> CoursesContent { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
