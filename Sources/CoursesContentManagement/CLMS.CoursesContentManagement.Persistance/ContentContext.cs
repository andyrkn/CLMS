using CLMS.CoursesContentManagement.Domain;
using CLMS.CoursesContentManagement.Persistance.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace CLMS.CoursesContentManagement.Persistance
{
    public class ContentContext : DbContext
    {
        public ContentContext(DbContextOptions<ContentContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<ContentHolder> ContentHolders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new FileContentConfiguration().Configure(modelBuilder.Entity<FileContent>());
            new ContentHolderConfiguration().Configure(modelBuilder.Entity<ContentHolder>());
        }
    }
}
