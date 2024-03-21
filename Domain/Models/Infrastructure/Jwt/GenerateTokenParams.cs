namespace Domain.Models.Infrastructure.Jwt;

public record GenerateTokenParams(
    Guid Id,
    string FirstName,
    string LastName,
    string Username,
    string RoleKey);