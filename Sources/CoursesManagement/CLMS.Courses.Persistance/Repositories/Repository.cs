using System;
using System.Linq;
using CSharpFunctionalExtensions;
using CLMS.Courses.Domain;
using Microsoft.EntityFrameworkCore;

namespace CLMS.Courses.Persistance
{
    public abstract class Repository<T> : IReadRepository<T>, IWriteRepository<T>
        where T : Course
    {
        private readonly CoursesContext context;
        protected readonly DbSet<T> enititesSet;

        protected Repository(CoursesContext context)
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