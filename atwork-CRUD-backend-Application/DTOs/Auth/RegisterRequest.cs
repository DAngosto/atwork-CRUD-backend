namespace atwork_CRUD_backend_Application.DTOs.Auth
{
    public class RegisterRequest
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Company { get; set; }
        public required string Phone { get; set; }
    }
}
