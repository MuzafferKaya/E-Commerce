using DomainModel.Entities.Staff;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainModel.Configurations
{
    public class StaffAccountConfiguration : IEntityTypeConfiguration<StaffAccount>
    {
        public void Configure(EntityTypeBuilder<StaffAccount> builder)
        {
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
