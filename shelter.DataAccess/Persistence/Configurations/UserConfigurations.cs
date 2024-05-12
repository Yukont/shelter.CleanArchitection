using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using shelter.Domain.UserAggregate;
using shelter.Domain.UserAggregate.ValueObjects;

namespace shelter.DataAccess.Persistence.Configurations;

internal class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => UserId.Create(value));

        builder.Property(u => u.FirstName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(u => u.LastName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(u => u.Email)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(u => u.Password)
            .HasMaxLength(300)
            .IsRequired();

        builder.Property(u => u.Phone)
            .HasMaxLength(13)
            .IsRequired();

        builder.HasOne(u => u.UserRole).WithMany(u => u.Users)
            .HasForeignKey(u => u.UserRoleId);
    }
}
