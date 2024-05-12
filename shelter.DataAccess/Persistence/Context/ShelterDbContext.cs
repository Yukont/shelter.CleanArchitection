using Microsoft.EntityFrameworkCore;
using shelter.Domain.AnimalAggregate;
using shelter.Domain.UserRoleAggregate;

namespace shelter.DataAccess.Persistence.Context;

public class ShelterDbContext : DbContext
{
    public ShelterDbContext(DbContextOptions<ShelterDbContext> options)
        : base(options)
    {
    }

    public DbSet<Animal> Animals { get; set; }
    public DbSet<UserRole> UserRoles {  get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(ShelterDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

}
