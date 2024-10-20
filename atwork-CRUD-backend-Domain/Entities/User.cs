namespace atwork_CRUD_backend_Domain.Entities
{
    public class User
    {
        public required Guid Id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
    }
}
