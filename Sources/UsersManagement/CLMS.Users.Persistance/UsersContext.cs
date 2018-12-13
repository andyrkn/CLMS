using System;
using CLMS.Users.Domain;
using Microsoft.EntityFrameworkCore;

namespace CLMS.Users.Persistance
{
    public class UsersContext : DbContext
    {
        public UsersContext(DbContextOptions<UsersContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        public DbSet<ApplicationUser> Users { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            var entityBuilder = modelBuilder.Entity<ApplicationUser>();
            entityBuilder.OwnsOne(x => x.FirstName, fn => fn.Property(x => x.Value).IsRequired());
            entityBuilder.OwnsOne(x => x.LastName, fn => fn.Property(x => x.Value).IsRequired());
        }
    }
}