using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.API.Auth;

public class SignInRequest
{
    [Length(maximumLength:30, minimumLength:5)]
    public string Username { get; set; }

    [PasswordPropertyText, Length(maximumLength: 20, minimumLength:5)]
    public string Password { get; set; }
}