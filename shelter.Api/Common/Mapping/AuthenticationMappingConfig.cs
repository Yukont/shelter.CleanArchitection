using Mapster;
using shelter.Application.Authentication.Commands.Register;
using shelter.Application.Authentication.Common;
using shelter.Application.Authentication.Queries.Login;
using shelter.Contracts.Authentications;

namespace shelter.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();

        config.NewConfig<LoginRequest, LoginQuery>();

        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest, src => src.User);
    }
}
