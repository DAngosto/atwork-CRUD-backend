using atwork_CRUD_backend_Domain.Entities;
using atwork_CRUD_backend_Infraestructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace atwork_CRUD_backend_Tests.IntegrationTests
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<AppDbContext>));

                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                services.AddDbContext<AppDbContext>(options =>
                {
                    options.UseInMemoryDatabase("AtworkDBDbForTesting");
                });

                var serviceProvider = services.BuildServiceProvider();

                using (var scope = serviceProvider.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<AppDbContext>();
                    var logger = scopedServices.GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

                    db.Database.EnsureCreated();

                    try
                    {
                        SeedTestData(db);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "Error seeding the database with test data. Error: {Message}", ex.Message);
                    }
                }
            });
        }

        private static void SeedTestData(AppDbContext context)
        {
            context.Users.AddRange(
            [
                new User { Id = Guid.Parse("9C7A736B-26A9-4100-A936-8CA9879857F3"), Email = "testuser@example.com", Password = "FYQDyPXS8y1wQDYk5DCg9TD76MTXzAcUNwXtB60/U6k=:DHKYQTZuvgdAF/9cD3E4Xw==", Company = "Test Company", Phone = "1234567890" }, // Password = "admin"
            ]);

            context.Countries.AddRange(
            [
                new Country { Id = Guid.Parse("421F1CFB-BE71-4422-BE33-87C16A673A84"), Name = "Spain", Code = "ES" },
            ]);

            context.SaveChanges();
        }
    }
}