using System.Net;
using Domain.Enumerators;
using Domain.Models.Common;
using Microsoft.AspNetCore.Mvc;

namespace API.Extensions;

public static class ResponseExtension
{
    public static void AddHandlerForBadRequest(this IServiceCollection services)
    {
        services.PostConfigure<ApiBehaviorOptions>(options =>
            options.InvalidModelStateResponseFactory = context =>
            {
                var serializableModelState = new SerializableError(context.ModelState);
                var errors = serializableModelState.FirstOrDefault().Value as string[];
                return new BadRequestObjectResult(
                    new Response<string>(new ErrorResponse
                        (HttpStatusCode.BadRequest, EResponseCode.InvalidRequest, errors.First())));
            });
    }
}