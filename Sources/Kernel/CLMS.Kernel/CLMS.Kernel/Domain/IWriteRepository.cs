namespace CLMS.Kernel.Domain
{
    public interface IWriteRepository<in T>
        where T : Entity
    {
        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void SaveChanges();
    }
}