using atwork_CRUD_backend_Application.DTOs.Employees;

namespace atwork_CRUD_backend_Application.Commands.Employees
{
    public class UpdateEmployeeCommand : ICommand<Guid>
    {
        public UpdateEmployeeRequest Request { get; }

        public UpdateEmployeeCommand(UpdateEmployeeRequest request)
        {
            Request = request;
        }
    }
}
