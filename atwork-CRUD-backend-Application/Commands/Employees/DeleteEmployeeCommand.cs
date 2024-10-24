namespace atwork_CRUD_backend_Application.Commands.Employees
{
    public class DeleteEmployeeCommand : ICommand<bool>
    {
        public Guid EmployeeId { get; }

        public DeleteEmployeeCommand(Guid employeeId)
        {
            EmployeeId = employeeId;
        }
    }
}
