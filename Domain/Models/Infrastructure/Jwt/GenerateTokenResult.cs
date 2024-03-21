namespace Domain.Models.Infrastructure.Jwt;

public record GenerateTokenResult(
    string Token,
    DateTime ExpireDate);