namespace atwork_CRUD_backend_Application.DTOs.Auth
{
    public class LoginDto
    {
        public required string Token { get; set; }
        public required Guid UserId { get; set; }
    }
}
