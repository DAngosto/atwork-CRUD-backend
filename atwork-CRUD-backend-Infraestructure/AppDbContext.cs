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
                new Employee { Id = Guid.Parse("E5A1C1CB-FBA6-4D81-B1EF-A25140C056A1"), FirstName = "Lara", LastName = "Sanchez", SecondLastName = "Perez", Email = "lara.sanchez@atwork.ai", JobTitle = "HR Specialist", WellnessScore = 87, ProductivityScore = 90, LastCheckIn = DateTime.Now }
            );
        }
    }
}
