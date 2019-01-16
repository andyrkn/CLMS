using System;
using System.Linq;
using CSharpFunctionalExtensions;
using CLMS.QuestionsManagement.Domain;
using Microsoft.EntityFrameworkCore;
using CLMS.Kernel;
using CLMS.Kernel.Domain;

namespace CLMS.QuestionsManagement.Persistance
{
    public abstract class Repository<T> : IReadRepository<T>, IWriteRepository<T>
        where T : Entity
    {
        private readonly QuestionsContext context;
        protected readonly DbSet<T> enititesSet;

        protected Repository(QuestionsContext context)
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

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}