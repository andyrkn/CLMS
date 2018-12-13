using System;
using CLMS.Users.Domain;
using Microsoft.EntityFrameworkCore;

namespace CLMS.Users.Persistance
{
    public class UsersContext : DbContext
    {
        public UsersContext ()
        {
            Database.EnsureCreated ();
        }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {

        }
    }
}