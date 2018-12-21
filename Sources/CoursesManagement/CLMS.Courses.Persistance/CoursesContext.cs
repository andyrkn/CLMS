using CLMS.Courses.Domain;
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
        {/*
            var entityBuilder = modelBuilder.Entity<Course>();
            entityBuilder.OwnsOne(x => x.Name, fn => fn.Property(x => x).IsRequired());
            entityBuilder.OwnsOne(x => x.Holder, fn => fn.Property(x => x).IsRequired());
            */
        }

    }
}
