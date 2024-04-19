using Microsoft.Extensions.DependencyInjection;
using shelter.Domain.Abstractions;
using MediatR;

namespace shelter.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(DependencyInjection).Assembly);

        services.AddScoped<IAnimalStatusService, AnimalStatusService>();

        return services;
    }
}
