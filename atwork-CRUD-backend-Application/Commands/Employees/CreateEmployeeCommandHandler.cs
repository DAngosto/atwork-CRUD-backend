using atwork_CRUD_backend_Domain.Entities;
using atwork_CRUD_backend_Domain.Repositories;
using MediatR;

namespace atwork_CRUD_backend_Application.Commands.Employees
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Guid>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUserRepository _userRepository;

        public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IUserRepository userRepository)
        {
            _employeeRepository = employeeRepository;
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(CreateEmployeeCommand command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(command.Request.UserId, cancellationToken);
            if (user is null)
                throw new KeyNotFoundException(UserErrors.NotFoundById(command.Request.UserId));

            var newEmployee = new Employee()
            {
                Id = Guid.NewGuid(),
                FirstName = command.Request.FirstName,
                LastName = command.Request.LastName,
                SecondLastName = command.Request.SecondLastName,
                Email = command.Request.Email,
                JobTitle = command.Request.JobTitle,
                WellnessScore = 0,
                ProductivityScore = 0,
                Address = command.Request.Address,
                Phone = command.Request.Phone,
                PictureUrl = command.Request.PictureUrl,
                CountryId = command.Request.Country,
                UserId = command.Request.UserId
            };
            bool created = await _employeeRepository.AddAsync(newEmployee, true, cancellationToken);
            if (!created)
            {
                throw new Exception(EmployeeErrors.EmployeeCreationUnavailable());
            }

            return newEmployee.Id;
        }
    }
}
