using System.Net;
using Domain.Enumerators;
using Domain.Helpers;

namespace Domain.Models.Common;

public class ErrorResponse
{
    public int Code { get; set; }

    public string Message { get; set; }

    public ErrorResponse(HttpStatusCode statusCode, EResponseCode code)
    {
        if (HttpContextHelper.Current?.Response != null)
            HttpContextHelper.Current.Response.StatusCode = (int)statusCode;

        Code = (int)code;
        Message = code.ToString(); // TODO: Localize error codes here
    }

    public ErrorResponse(HttpStatusCode statusCode, EResponseCode code, string message)
    {
        if (HttpContextHelper.Current?.Response != null)
            HttpContextHelper.Current.Response.StatusCode = (int)statusCode;

        Code = (int)code;
        Message = message;
    }

    public ErrorResponse(EResponseCode code)
    {
        if (HttpContextHelper.Current?.Response != null)
            HttpContextHelper.Current.Response.StatusCode = (int)HttpStatusCode.BadRequest;

        Code = (int)code;
        Message = code.ToString();
    }
}