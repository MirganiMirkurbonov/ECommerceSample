using Database.Extensions;
using Domain.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDomain(builder.Configuration)
    .AddDatabase();

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", 
        optional: true, reloadOnChange: true)
    .AddEnvironmentVariables(); 

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();