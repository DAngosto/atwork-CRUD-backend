using atwork_CRUD_backend_Application;
using atwork_CRUD_backend_Application.Validators;
using atwork_CRUD_backend_Domain.Repositories;
using atwork_CRUD_backend_Domain.Services;
using atwork_CRUD_backend_Infraestructure;
using atwork_CRUD_backend_Infraestructure.Configuration;
using atwork_CRUD_backend_Infraestructure.Repositories;
using atwork_CRUD_backend_Infraestructure.Services;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;

namespace atwork_CRUD_backend.ServiceCollectionExtensions
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddMediatRAndFluentValidatorServices(this IServiceCollection services)
        {
            var applicationAssembly = typeof(AssemblyReference).Assembly;
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(applicationAssembly);
            });
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddValidatorsFromAssembly(applicationAssembly);
            return services;
        }

        public static IServiceCollection AddFrontendCORSPolicy(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontEndOrigins", policy =>
                {
                    policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
                });
            });
            return services;
        }

        public static IServiceCollection AddInMemoryDatabase(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("AtworkDB"));
            return services;
        }

        public static IServiceCollection AddSettingsConfiguration(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
            return services;
        }

        public static IServiceCollection AddSerilogConfiguration(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddSerilog(lc => lc.ReadFrom.Configuration(configuration));
            return services;
        }

        public static IServiceCollection AddAuthConfiguration(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddAuthorization();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("JwtSettings:Secret").Value!)),
                        ValidIssuer = configuration.GetSection("JwtSettings:Issuer").Value!,
                        ValidAudience = configuration.GetSection("JwtSettings:Audience").Value!,
                        ClockSkew = TimeSpan.Zero
                    };
                });
            return services;
        }

        public static IServiceCollection AddSwaggerGenWithAuth(this IServiceCollection services)
        {
            services.AddSwaggerGen(o =>
            {
                o.CustomSchemaIds(id => id.FullName!.Replace('+', '-'));

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "JWT Authentication",
                    Description = "Enter your JWT token in this field",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    BearerFormat = "JWT"
                };

                o.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, securityScheme);

                var securityRequirement = new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = JwtBearerDefaults.AuthenticationScheme
                            }
                        },
                        []
                    }
                };

                o.AddSecurityRequirement(securityRequirement);
            });
            return services;
        }

        public static IServiceCollection AddServicesConfiguration(this IServiceCollection services)
        {
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddSingleton<IPasswordService, PasswordService>();
            services.AddSingleton<ITokenProviderService, TokenProviderService>();
            return services;
        }
    }

}
