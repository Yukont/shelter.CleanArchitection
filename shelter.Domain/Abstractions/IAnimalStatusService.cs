using shelter.Domain.Models;

namespace shelter.Domain.Abstractions
{
    public interface IAnimalStatusService
    {
        Task CreateAnimalStatus(AnimalStatus animalStatus);
        Task DeleteAnimalStatus(Guid id);
        Task<List<AnimalStatus>> GetAllAnimalStatuses();
        Task<AnimalStatus> GetAnimalStatus(Guid id);
        Task UpdateAnimalStatus(AnimalStatus animalStatus);
    }
}