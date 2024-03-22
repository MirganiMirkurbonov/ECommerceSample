using API.Extensions;
using Application.Extensions;
using Database.Extensions;
using Domain.Extensions;
using Domain.Helpers;
using Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();

var mapsterConfig = MapsterExtensions.CreateGlobalConfig();
builder.Services
    .AddDatabase(builder.Configuration)
    .AddDomain(builder.Configuration)
    .AddApplication(mapsterConfig)
    .AddInfrastructure();
mapsterConfig.Compile();

builder.Services
    .AddHttpContextAccessor()
    .AddHandlerForBadRequest();

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", 
        optional: true, reloadOnChange: true)
    .AddEnvironmentVariables(); 

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfigurations(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Services.GetService<IHttpContextAccessor>() != null)
    HttpContextHelper.Accessor = app.Services.GetRequiredService<IHttpContextAccessor>();

app.UseHttpsRedirection();
app.UseRouting();

app.UseEndpoints(endpoints => endpoints.MapControllers()); 

app.Run();