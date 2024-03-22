using System.Net;
using Application.Interfaces;
using Database.Context.Tables;
using Database.Interfaces;
using Domain.Enumerators;
using Domain.Helpers;
using Domain.Models.API.Auth;
using Domain.Models.Common;
using Domain.Models.Infrastructure.Jwt;
using Infrastructure.Interfaces;
using Mapster;

namespace Application.Services;

internal class AuthService(
    IGenericRepository<User> _userRepository,
    ITokenService _tokenService) : IAuthService
{
    public async Task<Response<AuthorizedResponse>> SignIn(SignInRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetBy(x => x.Username == request.Username, cancellationToken);
        if (user is null)
            return new ErrorResponse(HttpStatusCode.NotFound, EResponseCode.UserNotFound);
        
        if (CryptoHelper.ComputeSha256Hash(request.Password) != user.PasswordHash)
            return new ErrorResponse(HttpStatusCode.NotFound, EResponseCode.InvalidPassword);
        
        var tokenResult = _tokenService.GenerateToken(user.Adapt<GenerateTokenParams>());
        return tokenResult.Adapt<AuthorizedResponse>();
    }

    public async Task<Response<AuthorizedResponse>> SignUp(SignUpRequest request, CancellationToken cancellationToken)
    {
        request.FirstName = request.FirstName.Trim();
        request.Username = request.Username.Trim().ToLower();

        var isUsernameUnique = await _userRepository.IsUnique(x => x.Username == request.Username, cancellationToken);
        if (isUsernameUnique == false)
            return new ErrorResponse(HttpStatusCode.BadRequest, EResponseCode.UsernameAlreadyExists);

        var isEmailUnique =
            await _userRepository.IsUnique(x => x.Email != request.Email || x.PhoneNumber != request.PhoneNumber,
                cancellationToken);
        if (isEmailUnique == false)
            return new ErrorResponse(HttpStatusCode.BadRequest, EResponseCode.InvalidEmailOrPhone);
        
        var user = request.Adapt<User>();
        
        var newUser = await _userRepository.Insert(user, cancellationToken);
        var userToken = _tokenService.GenerateToken(newUser.Adapt<GenerateTokenParams>());
        return userToken.Adapt<AuthorizedResponse>();
    }
}