using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TPH.Entities;
using TPH.Enumerations;

namespace TPH.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasDiscriminator<int>(entity => entity.UserType)
                .HasValue<InternalUser>((int)UserType.InternalUser)
                .HasValue<Customer>((int)UserType.Customer)
                .HasValue<User>((int)UserType.Other);

            builder.ToTable(typeof(User).Name);
            builder.HasKey(entity => entity.Id);

            builder.Property(entity => entity.UserType).IsRequired(true);

            builder.HasIndex(entity => new { entity.Username, entity.UserType }).IsUnique(true);
            builder.HasIndex(entity => new { entity.Email, entity.UserType }).IsUnique(true);
            builder.HasIndex(entity => entity.PhoneNumber).IsUnique(false);

            builder.Property(entity => entity.FirstName)
                .IsUnicode(true)
                .IsRequired(true)
                .HasMaxLength(255);

            builder.Property(entity => entity.LastName)
               .IsUnicode(true)
               .IsRequired(true)
               .HasMaxLength(255);

            builder.Property(entity => entity.Email)
               .IsUnicode(false)
               .IsRequired(true)
               .HasMaxLength(255);

            builder.Property(entity => entity.PhoneNumber)
               .IsUnicode(false)
               .IsRequired(false)
               .HasMaxLength(255);

            builder.Property(entity => entity.Address)
              .IsUnicode(false)
              .IsRequired(false)
              .HasMaxLength(255);

            builder.Property(entity => entity.Username)
               .IsUnicode(false)
               .IsRequired(true)
               .HasMaxLength(255);

            builder.Property(entity => entity.PasswordHash)
               .IsUnicode(false)
               .IsRequired(true)
               .HasMaxLength(255);
        }
    }
}
