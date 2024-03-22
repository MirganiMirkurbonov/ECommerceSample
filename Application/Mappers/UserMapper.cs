using Database.Context.Tables;
using Domain.Models.API.Auth;
using Domain.Helpers;
using Mapster;

namespace Application.Mappers;

public class UserMapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config
            .NewConfig<SignUpRequest, User>()
            .ConstructUsing(src => ConstructParameters(src));
    }

    private static User ConstructParameters(SignUpRequest src)
    {
        return new User
        {
            FirstName = src.FirstName,
            LastName = src.LastName,
            Username = src.Username,
            Email = src.Email,
            PhoneNumber = src.PhoneNumber,
            PasswordHash = CryptoHelper.ComputeSha256Hash(src.Password)
        };
    }
}