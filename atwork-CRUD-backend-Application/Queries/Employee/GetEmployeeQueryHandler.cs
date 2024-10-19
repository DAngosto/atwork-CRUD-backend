using atwork_CRUD_backend_Application.DTOs;
using atwork_CRUD_backend_Domain.Entities;
using atwork_CRUD_backend_Domain.Repositories;
using Mapster;
using MediatR;

namespace atwork_CRUD_backend_Application.Queries.Employee
{
    public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, EmployeeDto>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeeQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<EmployeeDto> Handle(GetEmployeeQuery query, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByIdAsync(query.EmployeeId, cancellationToken);
            if (employee is null)
                throw new KeyNotFoundException(EmployeeErrors.NotFoundById(query.EmployeeId));
            return await employee.BuildAdapter().AdaptToTypeAsync<EmployeeDto>();
        }
    }
}
