using shelter.Application.Common.Interfaces.Persistence;
using shelter.DataAccess.Persistence.Context;
using shelter.Domain.AnimalAggregate;

namespace shelter.DataAccess.Persistence.Repositories;

public class AnimalRepository : IAnimalRepository
{
    private readonly ShelterDbContext _shelterDbContext;

    public AnimalRepository(ShelterDbContext shelterDbContext)
    {
        _shelterDbContext = shelterDbContext;
    }

    public void Add(Animal animal)
    {
        _shelterDbContext.Add(animal);
        _shelterDbContext.SaveChanges();
    }
}
