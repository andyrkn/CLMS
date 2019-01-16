using CLMS.Notification.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CLMS.Notification.Persistance.EntitiesConfiguration
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasIndex(ev => ev.OriginId).IsUnique();
            builder.HasMany(ev => ev.Subscriptions).WithOne();
        }
    }
}