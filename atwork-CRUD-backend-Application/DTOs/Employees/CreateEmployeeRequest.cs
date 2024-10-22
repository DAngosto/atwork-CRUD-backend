namespace atwork_CRUD_backend_Application.DTOs.Employees
{
    public class CreateEmployeeRequest
    {
        public required Guid UserId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? SecondLastName { get; set; }
        public required string Email { get; set; }
        public string? JobTitle { get; set; }
        public required string Address { get; set; }
        public required string Phone { get; set; }
        public required Guid Country { get; set; }
        public string? PictureUrl { get; set; }
    }
}
