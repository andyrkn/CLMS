using CLMS.Notification.Domain.Entities;
using CLMS.Notification.Persistance.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;

namespace CLMS.Notification.Persistance
{
    public class NotificationContext : DbContext
    {
        public NotificationContext(DbContextOptions<NotificationContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Event> Events { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new EventConfiguration().Configure(modelBuilder.Entity<Event>());
        }
    }
}
