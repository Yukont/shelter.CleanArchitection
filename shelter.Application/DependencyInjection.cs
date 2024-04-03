using Microsoft.Extensions.DependencyInjection;
using shelter.Application.Services;
using shelter.Application.Services.Authentications;
using shelter.Domain.Abstractions;

namespace shelter.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationsService, AuthenticationsService>();
        services.AddScoped<IAnimalStatusService, AnimalStatusService>();

        return services;
    }
}
