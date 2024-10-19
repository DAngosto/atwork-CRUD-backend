using atwork_CRUD_backend_Application;
using atwork_CRUD_backend_Application.Validators;
using atwork_CRUD_backend_Domain.Repositories;
using atwork_CRUD_backend_Infraestructure;
using atwork_CRUD_backend_Infraestructure.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

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

        public static IServiceCollection AddServicesConfiguration(this IServiceCollection services) 
        {
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            return services;
        }
    }

}
