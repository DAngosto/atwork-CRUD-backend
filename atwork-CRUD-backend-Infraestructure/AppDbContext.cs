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

            var userId = Guid.NewGuid(); // ID del User que se reutilizará en los empleados

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = userId,
                    Email = "example@company.com",
                    Password = "5GeULLC+4uTTtMp1mwP6YDdeWmNBMWNRdpAJPzzLv8w=:yl8ysCaor8YAmaHVNIDXfw==", //"string"
                    Company = "Example Corp",
                    Phone = "123-456-7890"
                });

            // Datos de ejemplo para los empleados del User
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
                    CountryId = countryId, // Relación con Country
                    UserId = userId // Relación con el User
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
                    CountryId = countryId, // Relación con Country
                    UserId = userId // Relación con el User
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
                    CountryId = countryId, // Relación con Country
                    UserId = userId // Relación con el User
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
                    CountryId = countryId, // Relación con Country
                    UserId = userId // Relación con el User
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
                    CountryId = countryId, // Relación con Country
                    UserId = userId // Relación con el User
                });

            //modelBuilder.Entity<User>().HasData(
            //    new User { Id = Guid.Parse("52DE8049-3CD1-4904-808E-9E120D213931"), Password = "pZIbUoIfztgTjqI6PX9LkW7J2ywKhV4ulf8jsaJxJ2A=:qzTYgezhYQ3fMuCB2fIIYw==", Email = "admin@atwork.ai" }
            //);

            //modelBuilder.Entity<Employee>().HasData(
            //    new Employee { Id = Guid.Parse("52DE8049-3CD1-4904-808E-9E120D213931"), FirstName = "Daniel", LastName = "Angosto", SecondLastName = "Martinez", Email = "d.angosto.martinez@atwork.ai", JobTitle = "Full Stack Developer", WellnessScore = 90, ProductivityScore = 85, LastCheckIn = DateTime.Now },
            //    new Employee { Id = Guid.Parse("A8F23E6A-4C57-4C12-B1AD-412F7F8B72E4"), FirstName = "Eve", LastName = "Thompson", Email = "eve.thompson@atwork.ai", JobTitle = "Project Manager", WellnessScore = 88, ProductivityScore = 92, LastCheckIn = DateTime.Now },
            //    new Employee { Id = Guid.Parse("B5B91BA2-D247-4F58-9D1D-F7C583E5B5D4"), FirstName = "Carlos", LastName = "Gonzalez", SecondLastName = "Rodriguez", Email = "carlos.gonzalez@atwork.ai", JobTitle = "Data Analyst", WellnessScore = 82, ProductivityScore = 87, LastCheckIn = DateTime.Now },
            //    new Employee { Id = Guid.Parse("C6738454-16F9-4D76-9551-08ADFE947C59"), FirstName = "Sophia", LastName = "Lopez", SecondLastName = "Mendez", Email = "sophia.lopez@atwork.ai", JobTitle = "UX Designer", WellnessScore = 91, ProductivityScore = 88, LastCheckIn = DateTime.Now },
            //    new Employee { Id = Guid.Parse("12FA1CBE-9D49-4D90-A820-8C75FC94D3A7"), FirstName = "Miguel", LastName = "Martinez", Email = "miguel.martinez@atwork.ai", JobTitle = "DevOps Engineer", WellnessScore = 78, ProductivityScore = 83, LastCheckIn = DateTime.Now },
            //    new Employee { Id = Guid.Parse("E5A1C1CB-FBA6-4D81-B1EF-A25140C056A1"), FirstName = "Lara", LastName = "Sanchez", SecondLastName = "Perez", Email = "lara.sanchez@atwork.ai", JobTitle = "HR Specialist", WellnessScore = 87, ProductivityScore = 90, LastCheckIn = DateTime.Now },
            //    new Employee { Id = Guid.Parse("9AAB69D4-4F2F-4BC8-8CE2-5FEE7ACF0ACF"), FirstName = "Alicia", LastName = "Garcia", SecondLastName = "Ruiz", Email = "alicia.garcia@atwork.ai", JobTitle = "Marketing Specialist", WellnessScore = 85, ProductivityScore = 89, LastCheckIn = DateTime.Now },
            //    new Employee { Id = Guid.Parse("4D5C5C94-6BFB-4A53-8AFA-5D99107498A0"), FirstName = "Bruno", LastName = "Hernandez", Email = "bruno.hernandez@atwork.ai", JobTitle = "Business Analyst", WellnessScore = 82, ProductivityScore = 91, LastCheckIn = DateTime.Now },
            //    new Employee { Id = Guid.Parse("2438EFD1-981E-4E67-BA1F-6B6E7B2C9B19"), FirstName = "Camila", LastName = "Ramos", SecondLastName = "Paredes", Email = "camila.ramos@atwork.ai", JobTitle = "Data Scientist", WellnessScore = 92, ProductivityScore = 95, LastCheckIn = DateTime.Now },
            //    new Employee { Id = Guid.Parse("09B8F5F5-5AA9-4F70-A26C-BEBF984C76DB"), FirstName = "David", LastName = "Salazar", Email = "david.salazar@atwork.ai", JobTitle = "Backend Developer", WellnessScore = 79, ProductivityScore = 84, LastCheckIn = DateTime.Now },
            //    new Employee { Id = Guid.Parse("5BBCCD8F-B950-44AA-9213-2F302C276A76"), FirstName = "Elena", LastName = "Moreno", SecondLastName = "Torres", Email = "elena.moreno@atwork.ai", JobTitle = "Frontend Developer", WellnessScore = 89, ProductivityScore = 90, LastCheckIn = DateTime.Now },
            //    new Employee { Id = Guid.Parse("F23D11E4-8D9C-43F1-B5A7-621B26247EFD"), FirstName = "Francisco", LastName = "Perez", Email = "francisco.perez@atwork.ai", JobTitle = "QA Engineer", WellnessScore = 81, ProductivityScore = 85, LastCheckIn = DateTime.Now },
            //    new Employee { Id = Guid.Parse("C7F9D7E3-FD50-4F6F-A28F-C5F6A8E9A354"), FirstName = "Gabriela", LastName = "Fernandez", Email = "gabriela.fernandez@atwork.ai", JobTitle = "Product Owner", WellnessScore = 86, ProductivityScore = 92, LastCheckIn = DateTime.Now },
            //    new Employee { Id = Guid.Parse("6AE8D507-BD08-4F6E-A429-9F1B8D5C7631"), FirstName = "Hugo", LastName = "Ortiz", Email = "hugo.ortiz@atwork.ai", JobTitle = "System Administrator", WellnessScore = 77, ProductivityScore = 80, LastCheckIn = DateTime.Now },
            //    new Employee { Id = Guid.Parse("0E767DD2-3A7D-4B65-B198-CEB7EAD44E45"), FirstName = "Isabel", LastName = "Diaz", SecondLastName = "Mora", Email = "isabel.diaz@atwork.ai", JobTitle = "Content Manager", WellnessScore = 88, ProductivityScore = 87, LastCheckIn = DateTime.Now },
            //    new Employee { Id = Guid.Parse("AD762AD8-2391-4A5A-BBC2-314EFD5AE44E"), FirstName = "Jorge", LastName = "Navarro", Email = "jorge.navarro@atwork.ai", JobTitle = "Cloud Architect", WellnessScore = 84, ProductivityScore = 93, LastCheckIn = DateTime.Now },
            //    new Employee { Id = Guid.Parse("C7FDCCBC-A7E3-467E-A44D-5894D94C916D"), FirstName = "Karen", LastName = "Soto", Email = "karen.soto@atwork.ai", JobTitle = "Recruiter", WellnessScore = 87, ProductivityScore = 89, LastCheckIn = DateTime.Now },
            //    new Employee { Id = Guid.Parse("3578BFC2-A50A-4BB7-B14E-85F48DFBC1F2"), FirstName = "Luis", LastName = "Rivas", Email = "luis.rivas@atwork.ai", JobTitle = "Mobile Developer", WellnessScore = 80, ProductivityScore = 83, LastCheckIn = DateTime.Now },
            //    new Employee { Id = Guid.Parse("6ACFD19C-DBA6-43F7-B18A-532EACF9BDB8"), FirstName = "Marta", LastName = "Fuentes", SecondLastName = "Vega", Email = "marta.fuentes@atwork.ai", JobTitle = "UI Designer", WellnessScore = 90, ProductivityScore = 92, LastCheckIn = DateTime.Now },
            //    new Employee { Id = Guid.Parse("DB983F87-2D0A-490E-9217-40356F70D52A"), FirstName = "Oscar", LastName = "Ramirez", Email = "oscar.ramirez@atwork.ai", JobTitle = "Tech Lead", WellnessScore = 85, ProductivityScore = 94, LastCheckIn = DateTime.Now },
            //    new Employee { Id = Guid.Parse("85B8E01A-9657-4B54-AC13-C1BFD6FA4AD3"), FirstName = "Paula", LastName = "Castro", SecondLastName = "Silva", Email = "paula.castro@atwork.ai", JobTitle = "Sales Manager", WellnessScore = 88, ProductivityScore = 91, LastCheckIn = DateTime.Now }
            //);
        }
    }
}
