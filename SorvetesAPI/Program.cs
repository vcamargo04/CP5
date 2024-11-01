using SorveteriaAPI.Configuration;
using SorveteriaAPI.Extensions;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;
AppConfiguration appConfiguration = new AppConfiguration();
configuration.Bind(appConfiguration);
builder.Services.Configure<AppConfiguration>(configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddMongoDbContexts(appConfiguration);
builder.Services.AddSwagger(appConfiguration);
builder.Services.AddRepositories();
builder.Services.AddHealthChecks(appConfiguration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHealthChecks("/health-check", new HealthCheckOptions()
    {
        Predicate = _ => true,
        ResponseWriter = HealthCheckExtensions.WriteResponse
    });
});

app.Run();
