namespace DataAccess
{
    public interface IGenericRepository<T>
        where T : class
    {
        void Add(T entity);

        T GetById(string id);
    }
}
