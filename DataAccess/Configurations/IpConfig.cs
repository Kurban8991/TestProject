using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    internal class IpConfig : IEntityTypeConfiguration<IpAddress>
    {
        public void Configure(EntityTypeBuilder<IpAddress> builder)
        {
            builder.HasKey(i => i.Ip);
        }
    }
}
