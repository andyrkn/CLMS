using System;
using System.Linq;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using CLMS.CoursesContentManagement.Domain;

namespace CLMS.CoursesContentManagement.Persistance
{
    public abstract class Repository<T> : IReadRepository<T>, IWriteRepository<T>
        where T : CourseContent
    {
        private readonly CoursesContentContext context;
        protected readonly DbSet<T> enititesSet;

        protected Repository(CoursesContentContext context)
        {
            this.context = context;
            enititesSet = context.Set<T>();
        }

        public Maybe<T> GetById(Guid id)
        {
            return enititesSet.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<T> GetAll()
        {
            return enititesSet;
        }

        public void Add(T entity)
        {
            enititesSet.Add(entity);
        }

        public void Update(T entity)
        {
            enititesSet.Update(entity);
        }

        public void Delete(T entity)
        {
            enititesSet.Remove(entity);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}