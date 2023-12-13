using DataAccess.Models;

namespace DataAccess
{
    public interface IUnitOfWork
    {
        IGenericRepository<IpAddress> IpAddressRepository { get; }

        void Save();
    }
}
