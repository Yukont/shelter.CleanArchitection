using Microsoft.Extensions.DependencyInjection;
using MediatR;
using shelter.Application.Authentication.Commands.Register;
using ErrorOr;
using shelter.Application.Authentication.Common;
using shelter.Application.Common.Behaviors;
using FluentValidation;
using System.Reflection;
using Microsoft.AspNetCore.Identity;
using FluentValidation.AspNetCore;

namespace shelter.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(DependencyInjection).Assembly);

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        //services.AddTransient<IValidator<RegisterCommand>, RegisterCommandValidator>();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}
