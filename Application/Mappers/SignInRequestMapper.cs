using Domain.Models.API.Auth;
using Mapster;

namespace Application.Mappers;

public class SignInRequestMapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config
            .NewConfig<SignInRequest, AuthorizedResponse>()
            .ConstructUsing(src => ConstructParameters(src));
    }

    private static AuthorizedResponse ConstructParameters(SignInRequest src)
    {
        return new AuthorizedResponse(Token: "test", expireDate: DateTime.Now);
    }
}