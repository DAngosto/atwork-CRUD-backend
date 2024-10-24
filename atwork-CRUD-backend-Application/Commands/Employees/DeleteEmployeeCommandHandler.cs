using atwork_CRUD_backend_Domain.Repositories;
using MediatR;

namespace atwork_CRUD_backend_Application.Commands.Employees
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<bool> Handle(DeleteEmployeeCommand command, CancellationToken cancellationToken)
        {
            return await _employeeRepository.DeleteAsync(command.EmployeeId, cancellationToken);
        }
    }
}
