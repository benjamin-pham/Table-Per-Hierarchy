using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TPH.Entities;

namespace TPH.Configurations
{
    public class InternalUserConfiguration : IEntityTypeConfiguration<InternalUser>
    {
        public void Configure(EntityTypeBuilder<InternalUser> builder)
        {
            builder.Property(entity => entity.BranchId).IsRequired(false);
            builder.Property(entity => entity.IsSuperAdmin).IsRequired(true);
            builder.Property(entity => entity.IsAdmin).IsRequired(true);
        }
    }
}
