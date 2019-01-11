using CLMS.QuestionsManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace CLMS.QuestionsManagement.Persistance
{
    public class QuestionsContext : DbContext
    {
        public QuestionsContext(DbContextOptions<QuestionsContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Question> Questions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
