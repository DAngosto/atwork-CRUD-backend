using atwork_CRUD_backend_Application.DTOs.Employees;

namespace atwork_CRUD_backend_Application.Commands.Employees
{
    public class DeleteEmployeesCommand : ICommand<bool>
    {
        public DeleteEmployeesRequest Request { get; }

        public DeleteEmployeesCommand(DeleteEmployeesRequest request)
        {
            Request = request;
        }
    }
}
