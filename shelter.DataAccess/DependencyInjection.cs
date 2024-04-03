using Microsoft.Extensions.DependencyInjection;
using shelter.DataAccess.Repositories;
using shelter.Domain.Abstractions;

namespace shelter.DataAccess;

public static class DependencyInjection
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services)
    {
        services.AddScoped<IAnimalStatusesRepository, AnimalStatusesRepository>();
        return services;
    }
}
