using Microsoft.EntityFrameworkCore;
using shelter.DataAccess.Context;
using shelter.DataAccess.Entities;
using shelter.Domain.Models;
using shelter.Domain.Abstractions;

namespace shelter.DataAccess.Repositories;

public class AnimalStatusesRepository : IAnimalStatusesRepository
{
    protected readonly ShelterDbContext _dbContext;

    public AnimalStatusesRepository(ShelterDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateAsync(AnimalStatus animalStatus)
    {
        var animalStatusEntity = new AnimalStatusEntity
        {
            Id = animalStatus.Id,
            Name = animalStatus.Name,
        };

        await _dbContext.AnimalStatuses.AddAsync(animalStatusEntity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        await _dbContext.AnimalStatuses
            .Where(a => a.Id == id)
            .ExecuteDeleteAsync();
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<AnimalStatus>> GetAllAsync()
    {
        List<AnimalStatusEntity> animalStatusEntity = await _dbContext.AnimalStatuses
            .AsNoTracking()
            .ToListAsync();

        return animalStatusEntity
            .Select(a => AnimalStatus.Create(a.Id, a.Name).animalStatus)
            .ToList();
    }

    public async Task<AnimalStatus> GetAsync(Guid id)
    {
        AnimalStatusEntity animalStatusEntity = await _dbContext.AnimalStatuses.FindAsync(id);
        return AnimalStatus.Create(animalStatusEntity.Id, animalStatusEntity.Name).animalStatus;
    }

    public async Task UpdateAsync(AnimalStatus animalStatus)
    {
        await _dbContext.AnimalStatuses
            .Where(a => a.Id == animalStatus.Id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(a => a.Name, a => animalStatus.Name));
        await _dbContext.SaveChangesAsync();
    }
}
