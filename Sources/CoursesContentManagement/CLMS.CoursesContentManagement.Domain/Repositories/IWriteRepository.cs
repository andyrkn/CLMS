namespace CLMS.CoursesContentManagement.Domain
{
    public interface IWriteRepository<in T>
        where T : CourseContent
    {
        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Save();
    }
}
