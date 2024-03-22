using Domain.Models.Infrastructure.Jwt;

namespace Infrastructure.Interfaces;

public interface ITokenService
{
    GenerateTokenResult GenerateToken(GenerateTokenParams tokenParams);
}