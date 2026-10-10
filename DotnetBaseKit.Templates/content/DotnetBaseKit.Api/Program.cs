using DotnetBaseKit.Api.Extensions;
using DotnetBaseKit.Application.Extensions;
using BASEKIT_COMPONENTS_PACKAGE.Api;
using BASEKIT_COMPONENTS_PACKAGE.Application;
using BASEKIT_COMPONENTS_PACKAGE.Infra.Sql;
using DotnetBaseKit.Infra.Context;
using DotnetBaseKit.Infra.Extensions;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// BASEKIT DEPENDENCIES
builder.Services.AddApi();
builder.Services.AddApplication();
builder.Services.AddDbContext<DotnetBaseKitContext>(configuration);

// PROJECT DEPENDENCIES
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwagger();
builder.Services.ConfigureCors();
builder.Services.AddApplicationServices();
builder.Services.AddRepositories();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", context =>
{
    context.Response.Redirect("/swagger");
    return Task.CompletedTask;
});

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.MapControllers();

app.Run();
