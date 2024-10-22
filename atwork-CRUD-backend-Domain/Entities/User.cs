namespace atwork_CRUD_backend_Domain.Entities
{
    public class User
    {
        public required Guid Id { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Company { get; set; }
        public required string Phone { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
