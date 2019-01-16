using System;
using System.Linq;
using CLMS.Kernel.Domain;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;

namespace CLMS.Notification.Persistance.Repository
{
    public abstract class Repository<T> : IReadRepository<T>, IWriteRepository<T>
        where T : Entity
    {
        private readonly NotificationContext context;
        protected DbSet<T> EntitiesSet;

        protected Repository(NotificationContext context)
        {
            this.context = context;
            EntitiesSet = context.Set<T>();
        }

        public Maybe<T> GetById(Guid id)
        {
            return DecoratedEntitiesSet(EntitiesSet).FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<T> GetAll()
        {
            return DecoratedEntitiesSet(EntitiesSet);
        }

        public void Add(T entity)
        {
            EntitiesSet.Add(entity);
        }

        public void Update(T entity)
        {
            EntitiesSet.Update(entity);
        }

        public void Delete(T entity)
        {
            EntitiesSet.Remove(entity);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public virtual IQueryable<T> DecoratedEntitiesSet(IQueryable<T> query)
        {
            return query;
        }
    }
}