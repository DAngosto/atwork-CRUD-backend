namespace atwork_CRUD_backend_Application.DTOs.Employees
{
    public class GetAllEmployeesFromUserDto
    {
        public int TotalRecords { get; set; }
        public required EmployeeDto[] Data { get; set; }
    }
}
