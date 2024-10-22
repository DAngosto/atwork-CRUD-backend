namespace atwork_CRUD_backend_Application.DTOs.Auth
{
    public class LoginRequest
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
