using System;
using System.Linq;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using CLMS.Kernel.Domain;

namespace CLMS.CoursesContentManagement.Persistance
{
    public abstract class Repository<T> : IReadRepository<T>, IWriteRepository<T>
        where T : Entity
    {
        private readonly ContentContext context;
        protected DbSet<T> EntitiesSet;

        protected Repository(ContentContext context)
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