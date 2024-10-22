using atwork_CRUD_backend_Application.DTOs.Employee;
using atwork_CRUD_backend_Domain.Repositories;
using Mapster;
using MediatR;

namespace atwork_CRUD_backend_Application.Queries.Employee
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, GetAllEmployeesDto>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetAllEmployeesQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<GetAllEmployeesDto> Handle(GetAllEmployeesQuery query, CancellationToken cancellationToken)
        {
            var employees = await _employeeRepository.GetAllAsync(query.Page, query.Size, cancellationToken);
            return new GetAllEmployeesDto() { Data = await employees.BuildAdapter().AdaptToTypeAsync<EmployeeDto[]>(), TotalRecords = await _employeeRepository.GetAllCountAsync(cancellationToken) };
        }
    }
}
