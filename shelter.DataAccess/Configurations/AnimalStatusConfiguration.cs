using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using shelter.DataAccess.Entities;
using shelter.Domain.Models;

namespace shelter.DataAccess.Configurations;

internal class AnimalStatusConfiguration : IEntityTypeConfiguration<AnimalStatusEntity>
{
    public void Configure(EntityTypeBuilder<AnimalStatusEntity> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Name)
            .IsRequired()
            .HasMaxLength(AnimalStatus.MAX_NAME_LENGTH);
    }
}
