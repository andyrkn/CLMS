using System;
using System.Linq;
using CLMS.Users.Domain;
using Microsoft.EntityFrameworkCore;

namespace CLMS.Users.Persistance
{
    public abstract class Repository<T> : IWriteRepository<T>, IReadRepository<T> where T : Entity
    {
        private readonly UsersContext context;
        protected readonly DbSet<T> entitiesSet;
        protected Repository (UsersContext context)
        {
            this.context = context;
            entitiesSet = context.Set<T> ();
        }
        public IQueryable<T> GetAll ()
        {
            return entitiesSet;
        }

        public void Add (T entity)
        {
            entitiesSet.Add (entity);
        }

        public void Save ()
        {
            context.SaveChanges ();
        }
    }
}