using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using shelter.Domain.AdoptionStatus.ValueObjects;
using shelter.Domain.Animal;
using shelter.Domain.Animal.ValueObjects;
using shelter.Domain.Gender.ValueObjects;
using shelter.Domain.HealthStatus.ValueObjects;
using shelter.Domain.Species.ValueObjects;
using shelter.Domain.Sterellized.ValueObjects;

namespace shelter.DataAccess.Persistence.Configurations;

internal class AnimalConfiguraions : IEntityTypeConfiguration<Animal>
{
    public void Configure(EntityTypeBuilder<Animal> builder)
    {
        ContigureAnimalsTable(builder);
        ContigureVaccinationsTable(builder);
    }

    private void ContigureVaccinationsTable(EntityTypeBuilder<Animal> builder)
    {
        builder.OwnsMany(a => a.Vaccinations, vb =>
        {
            vb.ToTable("Vaccination");

            vb.HasKey("Id", "AnimalId");

            vb.WithOwner().HasForeignKey("AnimalId");

            vb.Property(v => v.Id)
                .HasColumnName("Id")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => VaccinationId.Create(value));

            vb.Property(v => v.Name)
                .HasMaxLength(50);

            vb.Property(v => v.DateTime)
                .HasMaxLength(10);
        });

        builder.Metadata.FindNavigation(nameof(Animal.Vaccinations))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ContigureAnimalsTable(EntityTypeBuilder<Animal> builder)
    {
        builder.ToTable("Animal");

        builder.HasKey(a => a.Id);

        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => AnimalId.Create(value));

        builder.Property(a => a.Name)
            .HasMaxLength(50);

        builder.Property(a => a.Description)
            .HasMaxLength(300);

        builder.Property(a => a.Photo)
            .HasMaxLength(150);

        builder.Property(a => a.Age)
            .HasMaxLength(2);

        builder.Property(a => a.GenderId)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => GenderId.Create(value));

        builder.Property(a => a.HealthStatusId)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => HealthStatusId.Create(value));

        builder.Property(a => a.SpeciesId)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => SpeciesId.Create(value));

        builder.Property(a => a.SterilizedId)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => SterilizedId.Create(value));

        builder.Property(a => a.AdoptionStatusId)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => AdoptionStatusId.Create(value));
    }
}
