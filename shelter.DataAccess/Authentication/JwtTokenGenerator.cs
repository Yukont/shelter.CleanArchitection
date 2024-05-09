using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using shelter.Application.Common.Interfaces.Authentication;
using shelter.Application.Common.Interfaces.Service;
using shelter.Domain.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace shelter.DataAccess.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtSettings jwtSettings;
    private readonly IDateTimeProvider dateTimeProvider;

    public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtOptions)
    {
        this.dateTimeProvider = dateTimeProvider;
        this.jwtSettings = jwtOptions.Value;
    }

    public string GenerateToken(User user)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtSettings.Secret)),
            SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var securieyToken = new JwtSecurityToken(
            issuer: jwtSettings.Issuer,
            audience: jwtSettings.Audience,
            expires: dateTimeProvider.UtcNow.AddMinutes(jwtSettings.ExpiryMinutes),
            claims: claims,
            signingCredentials: signingCredentials
            );

        return new JwtSecurityTokenHandler().WriteToken(securieyToken);
    }
}
