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

            SeedTestData(modelBuilder);
        }

        private static void SeedTestData(ModelBuilder modelBuilder)
        {
            var usaCountryId = Guid.NewGuid();
            var esCountryId = Guid.NewGuid();
            var mxCountryId = Guid.NewGuid();
            var ukCountryId = Guid.NewGuid();
            var itCountryId = Guid.NewGuid();
            modelBuilder.Entity<Country>().HasData(
                new Country { Id = usaCountryId, Name = "United States", Code = "US" },
                new Country { Id = Guid.NewGuid(), Name = "Canada", Code = "CA" },
                new Country { Id = mxCountryId, Name = "Mexico", Code = "MX" },
                new Country { Id = Guid.NewGuid(), Name = "Argentina", Code = "AR" },
                new Country { Id = Guid.NewGuid(), Name = "Brazil", Code = "BR" },
                new Country { Id = esCountryId, Name = "Spain", Code = "ES" },
                new Country { Id = Guid.NewGuid(), Name = "France", Code = "FR" },
                new Country { Id = Guid.NewGuid(), Name = "Germany", Code = "DE" },
                new Country { Id = ukCountryId, Name = "United Kingdom", Code = "GB" },
                new Country { Id = itCountryId, Name = "Italy", Code = "IT" },
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
                    Email = "admin@admin.com",
                    Password = "FYQDyPXS8y1wQDYk5DCg9TD76MTXzAcUNwXtB60/U6k=:DHKYQTZuvgdAF/9cD3E4Xw==", //"admin"
                    Company = "Atwork",
                    Phone = "123-456-7890",
                    PictureUrl = "https://primefaces.org/cdn/primeng/images/demo/avatar/amyelsner.png"
                }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = Guid.NewGuid(),
                    FirstName = "John",
                    LastName = "Smith",
                    Email = "john.smith@atwork.com",
                    JobTitle = "Developer",
                    WellnessScore = 85,
                    ProductivityScore = 90,
                    Address = "123 Main St, New York",
                    Phone = "123-456-7890",
                    CountryId = usaCountryId,
                    UserId = userId,
                    PictureUrl = "https://primefaces.org/cdn/primeng/images/demo/avatar/asiyajavayant.png"
                },
                new Employee
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Carlos",
                    LastName = "Gómez",
                    SecondLastName = "Ruiz",
                    Email = "carlos.gomez@atwork.com",
                    JobTitle = "Project Manager",
                    WellnessScore = 80,
                    ProductivityScore = 85,
                    Address = "Calle Mayor, 45, Madrid",
                    Phone = "654-321-987",
                    CountryId = esCountryId,
                    UserId = userId,
                    PictureUrl = "https://primefaces.org/cdn/primeng/images/demo/avatar/onyamalimba.png"
                },
                new Employee
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Giovanni",
                    LastName = "Rossi",
                    SecondLastName = "Conti",
                    Email = "giovanni.rossi@atwork.com",
                    JobTitle = "Designer",
                    WellnessScore = 75,
                    ProductivityScore = 88,
                    Address = "Via Roma, 22, Rome",
                    Phone = "555-987-654",
                    CountryId = itCountryId,
                    UserId = userId,
                    PictureUrl = "https://primefaces.org/cdn/primeng/images/demo/avatar/ionibowcher.png"
                },
                new Employee
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Emily",
                    LastName = "Johnson",
                    Email = "emily.johnson@atwork.co.uk",
                    JobTitle = "Analyst",
                    WellnessScore = 90,
                    ProductivityScore = 92,
                    Address = "456 Queen St, London",
                    Phone = "020-1234-5678",
                    CountryId = ukCountryId,
                    UserId = userId,
                    PictureUrl = "https://primefaces.org/cdn/primeng/images/demo/avatar/xuxuefeng.png"
                },
                new Employee
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Luis",
                    LastName = "Hernández",
                    SecondLastName = "Pérez",
                    Email = "luis.hernandez@atwork.com",
                    JobTitle = "Sales Manager",
                    WellnessScore = 78,
                    ProductivityScore = 83,
                    Address = "Avenida Reforma, 100, Ciudad de México",
                    Phone = "55-1234-5678",
                    CountryId = mxCountryId,
                    UserId = userId,
                }
            );
        }
    }
}
