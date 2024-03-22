using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.Models.Infrastructure.Jwt;
using Domain.Options;
using Infrastructure.Interfaces;
using Infrastructure.Providers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Services;

internal class TokenService(IOptions<JwtOptions> _options, IDatetimeProvider _datetime) : ITokenService
{
    public GenerateTokenResult GenerateToken(GenerateTokenParams tokenParams)
    {
        var expireDate = _datetime.UtcNow().AddMinutes(_options.Value.ExpireMinutes);
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_options.Value.Key);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("Id", tokenParams.Id.ToString()),
                new Claim(ClaimTypes.Role, tokenParams.RoleKey),
                new Claim(ClaimTypes.NameIdentifier, tokenParams.FirstName),
                new Claim(ClaimTypes.Surname, tokenParams.LastName),
            }),
            Expires = expireDate,
            Issuer = _options.Value.Issuer,
            Audience = _options.Value.Audience,
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return new GenerateTokenResult(
            Token: tokenHandler.WriteToken(token),
            ExpireDate: expireDate);
    }
}