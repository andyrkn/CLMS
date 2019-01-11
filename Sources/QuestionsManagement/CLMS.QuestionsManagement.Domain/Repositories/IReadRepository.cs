using System;
using System.Linq;
using CSharpFunctionalExtensions;

namespace CLMS.QuestionsManagement.Domain
{
    public interface IReadRepository<T>
        where T : Question
    {
        Maybe<T> GetById(Guid id);

        IQueryable<T> GetAll();
    }
}
