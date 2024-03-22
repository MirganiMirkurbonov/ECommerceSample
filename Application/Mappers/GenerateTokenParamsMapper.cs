using Database.Context.Tables;
using Domain.Models.API.Auth;
using Domain.Models.Infrastructure.Jwt;
using Mapster;

namespace Application.Mappers;

public class GenerateTokenParamsMapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config
            .NewConfig<User, GenerateTokenParams>()
            .ConstructUsing(src => ConstructParameters(src));

        config
            .NewConfig<GenerateTokenResult, AuthorizedResponse>()
            .ConstructUsing(src => ConstructParameters(src));
    }

    private static AuthorizedResponse ConstructParameters(GenerateTokenResult src)
    {
        return new AuthorizedResponse(src.Token, src.ExpireDate);
    }

    private static GenerateTokenParams ConstructParameters(User src)
    {
        return new GenerateTokenParams(
            Id: src.Id,
            FirstName: src.FirstName,
            LastName: src.LastName,
            Username: src.Username,
            RoleKey: "user");
    }
}