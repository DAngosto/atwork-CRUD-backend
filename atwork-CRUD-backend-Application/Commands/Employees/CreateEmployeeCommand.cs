using atwork_CRUD_backend_Application.DTOs.Employees;

namespace atwork_CRUD_backend_Application.Commands.Employees
{
    public class CreateEmployeeCommand : ICommand<Guid>
    {
        public CreateEmployeeRequest Request { get; }

        public CreateEmployeeCommand(CreateEmployeeRequest request)
        {
            Request = request;
        }
    }
}
