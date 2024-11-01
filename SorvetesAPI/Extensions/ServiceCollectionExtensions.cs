using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using SorveteriaAPI.Configuration;
using SorveteriaDatabase;
using SorveteriaModel;
using SorvetesRepository;
using MongoDB.Driver;
using System.Reflection;
using System.IO;

namespace SorveteriaAPI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMongoDbContexts(this IServiceCollection services, AppConfiguration appConfiguration)
        {
            // Registra o cliente MongoDB como singleton
            services.AddSingleton<IMongoClient>(new MongoClient(appConfiguration.SorveteMongoDb.Connection));

            // Registra o contexto MongoDB como um serviço escopo
            services.AddScoped<FIAPMongoDBContext>(sp =>
            {
                var client = sp.GetRequiredService<IMongoClient>();
                return new FIAPMongoDBContext(client); // Passa o IMongoClient para o contexto
            });

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Sorvete>, MongoDbRepository<Sorvete>>();
            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services, AppConfiguration appConfiguration)
        {
            services.AddSwaggerGen(swagger =>
            {
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = appConfiguration.Swagger.Title,
                    Version = "v1",
                    Description = appConfiguration.Swagger.Description,
                    Contact = new OpenApiContact()
                    {
                        Email = appConfiguration.Swagger.Email,
                        Name = appConfiguration.Swagger.Name
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                swagger.IncludeXmlComments(xmlPath);
            });

            return services;
        }

        public static IServiceCollection AddHealthChecks(this IServiceCollection services, AppConfiguration appConfiguration)
        {
            services.AddHealthChecks()
                .AddMongoDb(appConfiguration.SorveteMongoDb.Connection);

            return services;
        }
    }
}
