using CLMS.Courses.Domain;
using CLMS.Courses.Persistance.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace CLMS.Courses.Persistance
{
    public class CoursesContext : DbContext
    {
        public CoursesContext(DbContextOptions<CoursesContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new CourseConfiguration().Configure(modelBuilder.Entity<Course>());
        }
    }
}
