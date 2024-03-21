using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace API.Generics;

public class GenericController<T> : ControllerBase where T : class
{
    protected CancellationToken CancellationToken => HttpContext.RequestAborted;
    protected Guid UserId => Guid.Parse(HttpContext.User.FindFirstValue("Id") ?? throw new UnauthorizedAccessException());
}