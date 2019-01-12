using System;
using System.Linq;
using CSharpFunctionalExtensions;
using CLMS.Kernel.Domain;
using Microsoft.EntityFrameworkCore;

namespace CLMS.Courses.Persistance
{
    public abstract class Repository<T> : IReadRepository<T>, IWriteRepository<T>
        where T : Entity
    {
        private readonly CoursesContext context;
        protected DbSet<T> EntitiesSet;

        protected Repository(CoursesContext context)
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