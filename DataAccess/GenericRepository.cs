using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : class
    {
        public GenericRepository(IpContext ipContext) 
        {
            _dbSet = ipContext.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public T GetById(string id)
        {
            return _dbSet.Find(id);
        }

        private DbSet<T> _dbSet;
    }
}
