using atwork_CRUD_backend_Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace atwork_CRUD_backend_Infraestructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User { Id = Guid.Parse("52DE8049-3CD1-4904-808E-9E120D213931"), Password = "pZIbUoIfztgTjqI6PX9LkW7J2ywKhV4ulf8jsaJxJ2A=:qzTYgezhYQ3fMuCB2fIIYw==", Email = "admin@atwork.ai" }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = Guid.Parse("52DE8049-3CD1-4904-808E-9E120D213931"), FirstName = "Daniel", LastName = "Angosto", SecondLastName = "Martinez", Email = "d.angosto.martinez@atwork.ai", JobTitle = "Full Stack Developer", WellnessScore = 90, ProductivityScore = 85, LastCheckIn = DateTime.Now },
                new Employee { Id = Guid.Parse("A8F23E6A-4C57-4C12-B1AD-412F7F8B72E4"), FirstName = "Eve", LastName = "Thompson", Email = "eve.thompson@atwork.ai", JobTitle = "Project Manager", WellnessScore = 88, ProductivityScore = 92, LastCheckIn = DateTime.Now },
                new Employee { Id = Guid.Parse("B5B91BA2-D247-4F58-9D1D-F7C583E5B5D4"), FirstName = "Carlos", LastName = "Gonzalez", SecondLastName = "Rodriguez", Email = "carlos.gonzalez@atwork.ai", JobTitle = "Data Analyst", WellnessScore = 82, ProductivityScore = 87, LastCheckIn = DateTime.Now },
                new Employee { Id = Guid.Parse("C6738454-16F9-4D76-9551-08ADFE947C59"), FirstName = "Sophia", LastName = "Lopez", SecondLastName = "Mendez", Email = "sophia.lopez@atwork.ai", JobTitle = "UX Designer", WellnessScore = 91, ProductivityScore = 88, LastCheckIn = DateTime.Now },
                new Employee { Id = Guid.Parse("12FA1CBE-9D49-4D90-A820-8C75FC94D3A7"), FirstName = "Miguel", LastName = "Martinez", Email = "miguel.martinez@atwork.ai", JobTitle = "DevOps Engineer", WellnessScore = 78, ProductivityScore = 83, LastCheckIn = DateTime.Now },
                new Employee { Id = Guid.Parse("E5A1C1CB-FBA6-4D81-B1EF-A25140C056A1"), FirstName = "Lara", LastName = "Sanchez", SecondLastName = "Perez", Email = "lara.sanchez@atwork.ai", JobTitle = "HR Specialist", WellnessScore = 87, ProductivityScore = 90, LastCheckIn = DateTime.Now },
                new Employee { Id = Guid.Parse("9AAB69D4-4F2F-4BC8-8CE2-5FEE7ACF0ACF"), FirstName = "Alicia", LastName = "Garcia", SecondLastName = "Ruiz", Email = "alicia.garcia@atwork.ai", JobTitle = "Marketing Specialist", WellnessScore = 85, ProductivityScore = 89, LastCheckIn = DateTime.Now },
                new Employee { Id = Guid.Parse("4D5C5C94-6BFB-4A53-8AFA-5D99107498A0"), FirstName = "Bruno", LastName = "Hernandez", Email = "bruno.hernandez@atwork.ai", JobTitle = "Business Analyst", WellnessScore = 82, ProductivityScore = 91, LastCheckIn = DateTime.Now },
                new Employee { Id = Guid.Parse("2438EFD1-981E-4E67-BA1F-6B6E7B2C9B19"), FirstName = "Camila", LastName = "Ramos", SecondLastName = "Paredes", Email = "camila.ramos@atwork.ai", JobTitle = "Data Scientist", WellnessScore = 92, ProductivityScore = 95, LastCheckIn = DateTime.Now },
                new Employee { Id = Guid.Parse("09B8F5F5-5AA9-4F70-A26C-BEBF984C76DB"), FirstName = "David", LastName = "Salazar", Email = "david.salazar@atwork.ai", JobTitle = "Backend Developer", WellnessScore = 79, ProductivityScore = 84, LastCheckIn = DateTime.Now },
                new Employee { Id = Guid.Parse("5BBCCD8F-B950-44AA-9213-2F302C276A76"), FirstName = "Elena", LastName = "Moreno", SecondLastName = "Torres", Email = "elena.moreno@atwork.ai", JobTitle = "Frontend Developer", WellnessScore = 89, ProductivityScore = 90, LastCheckIn = DateTime.Now },
                new Employee { Id = Guid.Parse("F23D11E4-8D9C-43F1-B5A7-621B26247EFD"), FirstName = "Francisco", LastName = "Perez", Email = "francisco.perez@atwork.ai", JobTitle = "QA Engineer", WellnessScore = 81, ProductivityScore = 85, LastCheckIn = DateTime.Now },
                new Employee { Id = Guid.Parse("C7F9D7E3-FD50-4F6F-A28F-C5F6A8E9A354"), FirstName = "Gabriela", LastName = "Fernandez", Email = "gabriela.fernandez@atwork.ai", JobTitle = "Product Owner", WellnessScore = 86, ProductivityScore = 92, LastCheckIn = DateTime.Now },
                new Employee { Id = Guid.Parse("6AE8D507-BD08-4F6E-A429-9F1B8D5C7631"), FirstName = "Hugo", LastName = "Ortiz", Email = "hugo.ortiz@atwork.ai", JobTitle = "System Administrator", WellnessScore = 77, ProductivityScore = 80, LastCheckIn = DateTime.Now },
                new Employee { Id = Guid.Parse("0E767DD2-3A7D-4B65-B198-CEB7EAD44E45"), FirstName = "Isabel", LastName = "Diaz", SecondLastName = "Mora", Email = "isabel.diaz@atwork.ai", JobTitle = "Content Manager", WellnessScore = 88, ProductivityScore = 87, LastCheckIn = DateTime.Now },
                new Employee { Id = Guid.Parse("AD762AD8-2391-4A5A-BBC2-314EFD5AE44E"), FirstName = "Jorge", LastName = "Navarro", Email = "jorge.navarro@atwork.ai", JobTitle = "Cloud Architect", WellnessScore = 84, ProductivityScore = 93, LastCheckIn = DateTime.Now },
                new Employee { Id = Guid.Parse("C7FDCCBC-A7E3-467E-A44D-5894D94C916D"), FirstName = "Karen", LastName = "Soto", Email = "karen.soto@atwork.ai", JobTitle = "Recruiter", WellnessScore = 87, ProductivityScore = 89, LastCheckIn = DateTime.Now },
                new Employee { Id = Guid.Parse("3578BFC2-A50A-4BB7-B14E-85F48DFBC1F2"), FirstName = "Luis", LastName = "Rivas", Email = "luis.rivas@atwork.ai", JobTitle = "Mobile Developer", WellnessScore = 80, ProductivityScore = 83, LastCheckIn = DateTime.Now },
                new Employee { Id = Guid.Parse("6ACFD19C-DBA6-43F7-B18A-532EACF9BDB8"), FirstName = "Marta", LastName = "Fuentes", SecondLastName = "Vega", Email = "marta.fuentes@atwork.ai", JobTitle = "UI Designer", WellnessScore = 90, ProductivityScore = 92, LastCheckIn = DateTime.Now },
                new Employee { Id = Guid.Parse("DB983F87-2D0A-490E-9217-40356F70D52A"), FirstName = "Oscar", LastName = "Ramirez", Email = "oscar.ramirez@atwork.ai", JobTitle = "Tech Lead", WellnessScore = 85, ProductivityScore = 94, LastCheckIn = DateTime.Now },
                new Employee { Id = Guid.Parse("85B8E01A-9657-4B54-AC13-C1BFD6FA4AD3"), FirstName = "Paula", LastName = "Castro", SecondLastName = "Silva", Email = "paula.castro@atwork.ai", JobTitle = "Sales Manager", WellnessScore = 88, ProductivityScore = 91, LastCheckIn = DateTime.Now }
            );
        }
    }
}
