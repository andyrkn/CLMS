namespace CLMS.QuestionsManagement.Domain
{
    public interface IWriteRepository<in T>
        where T: Question
    {
        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Save();
    }
}
