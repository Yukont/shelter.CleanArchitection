using shelter.Domain.AnimalAggregate;

namespace shelter.Application.Common.Interfaces.Persistence;

public interface IAnimalRepository
{
    void Add(Animal animal);
}
