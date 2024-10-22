namespace atwork_CRUD_backend_Application.DTOs.Shared
{
    public class CountryDto
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Code { get; set; }
    }
}
