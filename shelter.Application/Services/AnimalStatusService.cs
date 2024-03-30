using shelter.Domain.Abstractions;
using shelter.Domain.Models;

namespace shelter.Application.Services;

public class AnimalStatusService : IAnimalStatusService
{
    private readonly IAnimalStatusesRepository animalStatusesRepository;

    public AnimalStatusService(IAnimalStatusesRepository animalStatusesRepository)
    {
        this.animalStatusesRepository = animalStatusesRepository;
    }

    public async Task<List<AnimalStatus>> GetAllAnimalStatuses()
    {
        return await animalStatusesRepository.GetAllAsync();
    }
    public async Task<AnimalStatus> GetAnimalStatus(Guid id)
    {
        return await animalStatusesRepository.GetAsync(id);
    }
    public async Task CreateAnimalStatus(AnimalStatus animalStatus)
    {
        await animalStatusesRepository.CreateAsync(animalStatus);
    }
    public async Task UpdateAnimalStatus(AnimalStatus animalStatus)
    {
        await animalStatusesRepository.UpdateAsync(animalStatus);
    }
    public async Task DeleteAnimalStatus(Guid id)
    {
        await animalStatusesRepository.DeleteAsync(id);
    }
}
