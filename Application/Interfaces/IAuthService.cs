using Domain.Models.API.Auth;
using Domain.Models.Common;

namespace Application.Interfaces;

public interface IAuthService
{
    Task<Response<AuthorizedResponse>> SignIn(SignInRequest request, CancellationToken cancellationToken);
    Task<Response<AuthorizedResponse>> SignUp(SignUpRequest request, CancellationToken cancellationToken);
}