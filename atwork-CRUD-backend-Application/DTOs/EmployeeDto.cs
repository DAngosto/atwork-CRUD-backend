namespace atwork_CRUD_backend_Application.DTOs
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? SecondLastName { get; set; }
        public required string Email { get; set; }
        public string? JobTitle { get; set; }
        public int WellnessScore { get; set; }
        public int ProductivityScore { get; set; }
        public DateTime LastCheckIn { get; set; }
    }
}
