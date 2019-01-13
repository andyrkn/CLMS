using CLMS.CoursesContentManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace CLMS.CoursesContentManagement.Persistance
{
    public class ContentContext : DbContext
    {
        public ContentContext(DbContextOptions<ContentContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Content> CoursesContent { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
