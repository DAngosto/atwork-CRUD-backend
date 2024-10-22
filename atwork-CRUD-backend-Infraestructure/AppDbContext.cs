using atwork_CRUD_backend_Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace atwork_CRUD_backend_Infraestructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
           .HasOne(e => e.Country)      
           .WithMany()                    
           .HasForeignKey(e => e.CountryId);

            modelBuilder.Entity<User>()
           .HasMany(e => e.Employees)
           .WithOne(e => e.User)
           .HasForeignKey(e => e.UserId);

            var countryId = Guid.NewGuid();

            modelBuilder.Entity<Country>().HasData(
                new Country { Id = countryId, Name = "United States", Code = "US" },
                new Country { Id = Guid.NewGuid(), Name = "Canada", Code = "CA" },
                new Country { Id = Guid.NewGuid(), Name = "Mexico", Code = "MX" },
                new Country { Id = Guid.NewGuid(), Name = "Argentina", Code = "AR" },
                new Country { Id = Guid.NewGuid(), Name = "Brazil", Code = "BR" },
                new Country { Id = Guid.NewGuid(), Name = "Spain", Code = "ES" },
                new Country { Id = Guid.NewGuid(), Name = "France", Code = "FR" },
                new Country { Id = Guid.NewGuid(), Name = "Germany", Code = "DE" },
                new Country { Id = Guid.NewGuid(), Name = "United Kingdom", Code = "GB" },
                new Country { Id = Guid.NewGuid(), Name = "Italy", Code = "IT" },
                new Country { Id = Guid.NewGuid(), Name = "Australia", Code = "AU" },
                new Country { Id = Guid.NewGuid(), Name = "Japan", Code = "JP" },
                new Country { Id = Guid.NewGuid(), Name = "South Korea", Code = "KR" },
                new Country { Id = Guid.NewGuid(), Name = "China", Code = "CN" },
                new Country { Id = Guid.NewGuid(), Name = "India", Code = "IN" },
                new Country { Id = Guid.NewGuid(), Name = "Russia", Code = "RU" },
                new Country { Id = Guid.NewGuid(), Name = "South Africa", Code = "ZA" },
                new Country { Id = Guid.NewGuid(), Name = "Egypt", Code = "EG" },
                new Country { Id = Guid.NewGuid(), Name = "Turkey", Code = "TR" },
                new Country { Id = Guid.NewGuid(), Name = "Saudi Arabia", Code = "SA" },
                new Country { Id = Guid.NewGuid(), Name = "United Arab Emirates", Code = "AE" },
                new Country { Id = Guid.NewGuid(), Name = "Israel", Code = "IL" },
                new Country { Id = Guid.NewGuid(), Name = "Nigeria", Code = "NG" },
                new Country { Id = Guid.NewGuid(), Name = "Kenya", Code = "KE" },
                new Country { Id = Guid.NewGuid(), Name = "Ghana", Code = "GH" },
                new Country { Id = Guid.NewGuid(), Name = "Morocco", Code = "MA" },
                new Country { Id = Guid.NewGuid(), Name = "Chile", Code = "CL" },
                new Country { Id = Guid.NewGuid(), Name = "Colombia", Code = "CO" },
                new Country { Id = Guid.NewGuid(), Name = "Peru", Code = "PE" },
                new Country { Id = Guid.NewGuid(), Name = "Venezuela", Code = "VE" },
                new Country { Id = Guid.NewGuid(), Name = "Uruguay", Code = "UY" },
                new Country { Id = Guid.NewGuid(), Name = "Paraguay", Code = "PY" },
                new Country { Id = Guid.NewGuid(), Name = "Bolivia", Code = "BO" },
                new Country { Id = Guid.NewGuid(), Name = "Ecuador", Code = "EC" },
                new Country { Id = Guid.NewGuid(), Name = "Costa Rica", Code = "CR" },
                new Country { Id = Guid.NewGuid(), Name = "Panama", Code = "PA" },
                new Country { Id = Guid.NewGuid(), Name = "Cuba", Code = "CU" },
                new Country { Id = Guid.NewGuid(), Name = "Dominican Republic", Code = "DO" },
                new Country { Id = Guid.NewGuid(), Name = "Honduras", Code = "HN" },
                new Country { Id = Guid.NewGuid(), Name = "El Salvador", Code = "SV" },
                new Country { Id = Guid.NewGuid(), Name = "Guatemala", Code = "GT" },
                new Country { Id = Guid.NewGuid(), Name = "Nicaragua", Code = "NI" },
                new Country { Id = Guid.NewGuid(), Name = "Portugal", Code = "PT" },
                new Country { Id = Guid.NewGuid(), Name = "Netherlands", Code = "NL" },
                new Country { Id = Guid.NewGuid(), Name = "Belgium", Code = "BE" },
                new Country { Id = Guid.NewGuid(), Name = "Sweden", Code = "SE" },
                new Country { Id = Guid.NewGuid(), Name = "Norway", Code = "NO" },
                new Country { Id = Guid.NewGuid(), Name = "Denmark", Code = "DK" },
                new Country { Id = Guid.NewGuid(), Name = "Finland", Code = "FI" },
                new Country { Id = Guid.NewGuid(), Name = "Switzerland", Code = "CH" },
                new Country { Id = Guid.NewGuid(), Name = "Austria", Code = "AT" },
                new Country { Id = Guid.NewGuid(), Name = "Poland", Code = "PL" },
                new Country { Id = Guid.NewGuid(), Name = "Czech Republic", Code = "CZ" },
                new Country { Id = Guid.NewGuid(), Name = "Hungary", Code = "HU" },
                new Country { Id = Guid.NewGuid(), Name = "Greece", Code = "GR" },
                new Country { Id = Guid.NewGuid(), Name = "New Zealand", Code = "NZ" },
                new Country { Id = Guid.NewGuid(), Name = "Philippines", Code = "PH" },
                new Country { Id = Guid.NewGuid(), Name = "Thailand", Code = "TH" },
                new Country { Id = Guid.NewGuid(), Name = "Vietnam", Code = "VN" },
                new Country { Id = Guid.NewGuid(), Name = "Malaysia", Code = "MY" },
                new Country { Id = Guid.NewGuid(), Name = "Singapore", Code = "SG" },
                new Country { Id = Guid.NewGuid(), Name = "Indonesia", Code = "ID" },
                new Country { Id = Guid.NewGuid(), Name = "Pakistan", Code = "PK" },
                new Country { Id = Guid.NewGuid(), Name = "Bangladesh", Code = "BD" }
            );

            var userId = Guid.NewGuid(); 

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = userId,
                    Email = "test@gmail.com",
                    Password = "5GeULLC+4uTTtMp1mwP6YDdeWmNBMWNRdpAJPzzLv8w=:yl8ysCaor8YAmaHVNIDXfw==", //"string"
                    Company = "Example Corp",
                    Phone = "123-456-7890",
                    PictureUrl = "https://primefaces.org/cdn/primeng/images/demo/avatar/amyelsner.png"
                });

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = Guid.NewGuid(),
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com",
                    JobTitle = "Developer",
                    WellnessScore = 85,
                    ProductivityScore = 90,
                    Address = "123 Main St",
                    LastCheckIn = DateTime.Now,
                    Phone = "555-1234",
                    CountryId = countryId,
                    UserId = userId,
                    PictureUrl = "https://primefaces.org/cdn/primeng/images/demo/avatar/asiyajavayant.png"

                },
                new Employee
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Jane",
                    LastName = "Smith",
                    Email = "jane.smith@example.com",
                    JobTitle = "Manager",
                    WellnessScore = 80,
                    ProductivityScore = 85,
                    Address = "456 Market St",
                    LastCheckIn = DateTime.Now,
                    Phone = "555-5678",
                    CountryId = countryId,
                    UserId = userId,
                    PictureUrl = "https://primefaces.org/cdn/primeng/images/demo/avatar/onyamalimba.png"
                },
                new Employee
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Alice",
                    LastName = "Johnson",
                    Email = "alice.johnson@example.com",
                    JobTitle = "Analyst",
                    WellnessScore = 75,
                    ProductivityScore = 88,
                    Address = "789 Elm St",
                    LastCheckIn = DateTime.Now,
                    Phone = "555-8765",
                    CountryId = countryId,
                    UserId = userId,
                    PictureUrl = "https://primefaces.org/cdn/primeng/images/demo/avatar/ionibowcher.png"
                },
                new Employee
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Bob",
                    LastName = "Brown",
                    Email = "bob.brown@example.com",
                    JobTitle = "Consultant",
                    WellnessScore = 78,
                    ProductivityScore = 80,
                    Address = "321 Oak St",
                    LastCheckIn = DateTime.Now,
                    Phone = "555-2345",
                    CountryId = countryId,
                    UserId = userId,
                    PictureUrl = "https://primefaces.org/cdn/primeng/images/demo/avatar/xuxuefeng.png"
                },
                new Employee
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Charlie",
                    LastName = "Davis",
                    Email = "charlie.davis@example.com",
                    JobTitle = "Designer",
                    WellnessScore = 82,
                    ProductivityScore = 92,
                    Address = "654 Pine St",
                    LastCheckIn = DateTime.Now,
                    Phone = "555-3456",
                    CountryId = countryId,
                    UserId = userId
                });
        }
    }
}
