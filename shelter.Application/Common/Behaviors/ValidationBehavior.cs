using ErrorOr;
using FluentValidation;
using MediatR;

namespace shelter.Application.Common.Behaviors;

internal class ValidationBehavior<TRequest, TResponce> : IPipelineBehavior<TRequest, TResponce> 
    where TRequest : IRequest<TResponce>
    where TResponce : IErrorOr
{
    private readonly IValidator<TRequest>? _validator;

    public ValidationBehavior(IValidator<TRequest>? validator = null)
    {
        _validator = validator;
    }

    public async Task<TResponce> Handle(TRequest request, RequestHandlerDelegate<TResponce> next, CancellationToken cancellationToken)
    {
        if (_validator is null)
        {
            return await next();
        }

        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (validationResult.IsValid)
        {
            return await next();
        }

        var errors = validationResult.Errors
            .ConvertAll(validationFailure => Error.Validation(
                validationFailure.PropertyName, 
                validationFailure.ErrorMessage))
            .ToList();

        return (dynamic)errors;
    }
}
