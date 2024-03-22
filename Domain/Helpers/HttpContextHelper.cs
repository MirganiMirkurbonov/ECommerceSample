using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;

namespace Domain.Helpers;

public class HttpContextHelper
{
    public static IHttpContextAccessor Accessor;
    
    public static HttpContext Current => Accessor?.HttpContext;

    public static string CurrentMethod => GetCurrentMethod();

    public static Guid UserId => Guid.Parse(Current.User.Claims.FirstOrDefault(x => x.Type == "ID").Value);

    public static bool UserIsAdmin => Current.User.Claims.FirstOrDefault(x => x.Type.Equals("admin", StringComparison.CurrentCultureIgnoreCase))?.Value == "1";

    private static string? PathAndQuery => Current.Request.GetEncodedPathAndQuery();
    public static string RequestUrl => Accessor.HttpContext.Request.GetDisplayUrl().Replace(PathAndQuery, "/");

    private static string GetCurrentMethod()
    {
        var request = Accessor?.HttpContext?.Request;
        if (request == null)
            return string.Empty;

        var pathSegments = request.Path.Value?.Split('/');
        return pathSegments?.Length > 1 ? $"{pathSegments[^2].ToLower()}_{pathSegments[^1].ToLower()}" : string.Empty;
    }

 
    public static void SetErrorInBodyCode()
        => SetStatusCode(HttpStatusCode.BadRequest);
    
    private static void SetStatusCode(HttpStatusCode code)
    {
        if (Current?.Response != null)
            Current.Response.StatusCode = (int)code;
    }
}