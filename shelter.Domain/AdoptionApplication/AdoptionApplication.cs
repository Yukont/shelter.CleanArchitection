using shelter.Domain.AdoptionApplication.ValueObjects;
using shelter.Domain.AdoptionApplicationStatus.ValueObjects;
using shelter.Domain.Animal.ValueObjects;
using shelter.Domain.Common.Models;
using shelter.Domain.User.ValueObjects;

namespace shelter.Domain.AdoptionApplication;

public sealed class AdoptionApplication : AggregateRoot<AdoptionApplicationId>
{
    public UserId UserId { get; }
    public AnimalId AnimalId { get; }
    public AdoptionApplicationStatusId AdoptionApplicationStatusId { get; }
    public string Description { get; }
    private AdoptionApplication(
        AdoptionApplicationId id,
        UserId userId,
        AnimalId animalId,
        AdoptionApplicationStatusId adoptionApplicationStatusId,
        string description)
        : base(id)
    {
        UserId = userId;
        AnimalId = animalId;
        AdoptionApplicationStatusId = adoptionApplicationStatusId;
        Description = description;
    }
    public static AdoptionApplication Create(
        UserId userId,
        AnimalId animalId,
        AdoptionApplicationStatusId adoptionApplicationStatusId,
        string description)
    {
        return new(AdoptionApplicationId.CreateUnique(), userId, animalId, adoptionApplicationStatusId, description);
    }
#pragma warning disable CS8618
    private AdoptionApplication()
    {

    }
#pragma warning restore CS8618 
}
