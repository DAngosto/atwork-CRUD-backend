namespace atwork_CRUD_backend_Application.DTOs.Employees
{
    public class DeleteEmployeesRequest
    {
        public required Guid[] EmployeeIds { get; set; }
    }
}
