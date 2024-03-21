namespace Domain.Models.API.Auth;

public record AuthorizedResponse(
    string Token,
    DateTime expireDate);