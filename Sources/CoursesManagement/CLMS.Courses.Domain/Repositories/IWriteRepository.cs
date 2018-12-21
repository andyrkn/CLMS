namespace CLMS.Courses.Domain
{
    public interface IWriteRepository<in T>
        where T: Course
    {
        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Save();
    }
}
