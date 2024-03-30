using shelter.Domain.Models;

namespace shelter.Domain.Abstractions;

public interface IAnimalStatusesRepository
{
    Task<List<AnimalStatus>> GetAllAsync();
    Task<AnimalStatus> GetAsync(Guid id);
    Task CreateAsync(AnimalStatus animalStatus);
    Task UpdateAsync(AnimalStatus animalStatus);
    Task DeleteAsync(Guid id);
}
