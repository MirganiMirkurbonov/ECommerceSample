using Domain.Helpers;

namespace Domain.Models.Common;

public class Response<T>
{
    public bool Success { get; set; } = true;

    public ErrorResponse? Error { get; set; }

    public T? Result { get; set; }

    public Response(T? result)
    {
        HttpContextHelper.Current.Response.StatusCode = 200;

        Result = result;
    }

    public Response(ErrorResponse error)
    {
        Error = error;
        Success = false;
    }
    
    public static implicit operator Response<T>(T result)
    {
        return new Response<T>(result);
    }

    public static implicit operator Response<T>(ErrorResponse error)
    {
        return new Response<T>(error);
    }
}