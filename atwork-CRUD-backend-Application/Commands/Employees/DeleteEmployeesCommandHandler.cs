using atwork_CRUD_backend_Domain.Repositories;
using MediatR;

namespace atwork_CRUD_backend_Application.Commands.Employees
{
    public class DeleteEmployeesCommandHandler : IRequestHandler<DeleteEmployeesCommand, bool>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public DeleteEmployeesCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<bool> Handle(DeleteEmployeesCommand command, CancellationToken cancellationToken)
        {
            foreach (var employeeId in command.Request.EmployeeIds)
            {
                await _employeeRepository.DeleteAsync(employeeId, cancellationToken);
            }
            return true;
        }
    }
}
