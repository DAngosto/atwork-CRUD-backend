using atwork_CRUD_backend_Domain.Entities;
using atwork_CRUD_backend_Domain.Repositories;
using MediatR;

namespace atwork_CRUD_backend_Application.Commands.Employees
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Guid>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUserRepository _userRepository;

        public UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IUserRepository userRepository)
        {
            _employeeRepository = employeeRepository;
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(UpdateEmployeeCommand command, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByIdAsync(command.Request.EmployeeId, cancellationToken);
            if (employee is null)
                throw new KeyNotFoundException(EmployeeErrors.NotFoundById(command.Request.EmployeeId));

            employee.FirstName = command.Request.FirstName;
            employee.LastName = command.Request.LastName;
            employee.SecondLastName = command.Request.SecondLastName;
            employee.Email = command.Request.Email;
            employee.JobTitle = command.Request.JobTitle;
            employee.WellnessScore = 0;
            employee.ProductivityScore = 0;
            employee.Address = command.Request.Address;
            employee.Phone = command.Request.Phone;
            employee.PictureUrl = command.Request.PictureUrl;
            employee.CountryId = command.Request.Country;
            employee.Country = null;

            bool updated = await _employeeRepository.UpdateAsync(employee, cancellationToken);
            if (!updated)
            {
                throw new Exception(EmployeeErrors.EmployeeUpdateUnavailable());
            }

            return employee.Id;
        }
    }
}
