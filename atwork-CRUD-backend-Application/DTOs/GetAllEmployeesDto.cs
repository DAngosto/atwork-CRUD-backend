namespace atwork_CRUD_backend_Application.DTOs
{
    public class GetAllEmployeesDto
    {
        public int TotalRecords { get; set; }
        public required EmployeeDto[] Data { get; set; }
    }
}
