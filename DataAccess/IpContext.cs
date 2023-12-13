using DataAccess.Configurations;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class IpContext : DbContext
    {
        public IpContext(DbContextOptions options) : base(options) 
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new IpConfig());
        }

        public DbSet<IpAddress> IpAddresses { get; set; }
    }
}
