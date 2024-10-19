using atwork_CRUD_backend_Application.DTOs;

namespace atwork_CRUD_backend_Application.Queries.Employee
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
