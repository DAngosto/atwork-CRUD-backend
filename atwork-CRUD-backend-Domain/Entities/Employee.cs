namespace atwork_CRUD_backend_Domain.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? SecondLastName { get; set; }
        public required string Email { get; set; }
        public string? JobTitle { get; set; }
        public int WellnessScore { get; set; } 
        public int ProductivityScore { get; set; }
        public required string Address { get; set; }
        public DateTime LastCheckIn { get; set; }
        public required string Phone { get; set; }
        public string? PictureUrl { get; set; }
        public Guid CountryId { get; set; }
        public Country? Country { get; set; }
        public required Guid UserId { get; set; }
        public User? User { get; set; }
    }
}
