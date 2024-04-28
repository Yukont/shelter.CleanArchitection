using Microsoft.AspNetCore.Mvc.Infrastructure;
using shelter.Api.Common.Error;
using shelter.Api.Common.Mapping;

namespace shelter.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddMappings();

        services.AddSingleton<ProblemDetailsFactory, ShelterProblemDelailsFactory>();

        return services;
    }
}
