using Microsoft.EntityFrameworkCore;
using shelter.DataAccess.Entities;

namespace shelter.DataAccess.Context;

public class ShelterDbContext : DbContext
{
    public ShelterDbContext(DbContextOptions<ShelterDbContext> options)
        : base(options)
    {
    }

    public DbSet<AnimalStatusEntity> AnimalStatuses {get; set;}
}
