using DataAccess.Models;

namespace DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        public IGenericRepository<IpAddress> IpAddressRepository { get; }

        public UnitOfWork(
            IpContext ipContext, 
            IGenericRepository<IpAddress> ipAddressRepository) 
        {
            _ipContext = ipContext;
            IpAddressRepository = ipAddressRepository;
        }

        public void Save()
        {
            _ipContext.SaveChanges();
        }

        private readonly IpContext _ipContext;
    }
}
