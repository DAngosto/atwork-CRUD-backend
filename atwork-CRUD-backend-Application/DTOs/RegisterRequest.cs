namespace atwork_CRUD_backend_Application.DTOs
{
    public class RegisterRequest
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
