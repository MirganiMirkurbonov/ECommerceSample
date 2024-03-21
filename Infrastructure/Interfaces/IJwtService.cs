using Domain.Models.Infrastructure.Jwt;

namespace Infrastructure.Interfaces;

public interface IJwtService
{
    GenerateTokenResult GenerateToken(GenerateTokenParams tokenParams);
}