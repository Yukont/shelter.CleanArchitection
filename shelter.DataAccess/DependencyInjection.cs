using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using shelter.Application.Common.Interfaces.Authentication;
using shelter.Application.Common.Interfaces.Service;
using shelter.DataAccess.Authentication;
using shelter.DataAccess.Repositories;
using shelter.DataAccess.Services;
using shelter.Domain.Abstractions;

namespace shelter.DataAccess;

public static class DependencyInjection
{
    public static IServiceCollection AddDataAccess(
        this IServiceCollection services, 
        ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IAnimalStatusesRepository, AnimalStatusesRepository>();
        return services;
    }
}
