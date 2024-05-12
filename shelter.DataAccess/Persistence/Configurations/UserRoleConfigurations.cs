using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using shelter.Domain.UserRoleAggregate;
using shelter.Domain.UserRoleAggregate.ValueObjects;

namespace shelter.DataAccess.Persistence.Configurations;

internal class UserRoleConfigurations : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable("UserRole");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => UserRoleId.Create(value));

        builder.Property(u => u.Name)
            .HasMaxLength(50)
            .IsRequired();
    }
}
