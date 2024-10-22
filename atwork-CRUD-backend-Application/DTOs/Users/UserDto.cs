namespace atwork_CRUD_backend_Application.DTOs.Users
{
    public class UserDto
    {
        public required Guid Id { get; set; }
        public required string Email { get; set; }
        public required string Company { get; set; }
        public required string Phone { get; set; }
        public string? PictureUrl { get; set; }
    }
}
