using API.Generics;
using Application.Interfaces;
using Domain.Models.API.Auth;
using Domain.Models.Common;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService _authService) : GenericController<AuthController>
{
    [HttpPost("sign-in")]
    public async Task<Response<AuthorizedResponse>> SignIn(SignInRequest request)
    {
        return await _authService.SignIn(request, CancellationToken);
    }

    [HttpPost("sign-up")]
    public async Task<Response<AuthorizedResponse>> SignUp(SignUpRequest request)
    {
        return await _authService.SignUp(request, CancellationToken);
    }
}