using atwork_CRUD_backend_Application.DTOs.Employees;

namespace atwork_CRUD_backend_Application.Queries.Employees
{
    public class GetEmployeeQuery : IQuery<EmployeeDto>
    {
        public Guid EmployeeId { get; }

        public GetEmployeeQuery(Guid employeeId)
        {
            EmployeeId = employeeId;
        }
    }
}
