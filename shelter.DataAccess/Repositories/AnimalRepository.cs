using shelter.Application.Common.Interfaces.Persistence;
using shelter.Domain.Animal;

namespace shelter.DataAccess.Repositories;

public class AnimalRepository : IAnimalRepository
{
    private static readonly List<Animal> _animals = new();
    public void Add(Animal animal)
    {
        _animals.Add(animal);
    }
}
