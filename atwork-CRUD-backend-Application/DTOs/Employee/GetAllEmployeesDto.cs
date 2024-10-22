namespace atwork_CRUD_backend_Application.DTOs.Employee
{
    public class GetAllEmployeesDto
    {
        public int TotalRecords { get; set; }
        public required EmployeeDto[] Data { get; set; }
    }
}
