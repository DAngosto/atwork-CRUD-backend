using atwork_CRUD_backend_Application.DTOs.Employees;
using atwork_CRUD_backend_Domain.Repositories;
using Mapster;
using MediatR;

namespace atwork_CRUD_backend_Application.Queries.Employees
{
    public class GetAllEmployeesFromUserQueryHandler : IRequestHandler<GetAllEmployeesFromUserQuery, GetAllEmployeesFromUserDto>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetAllEmployeesFromUserQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<GetAllEmployeesFromUserDto> Handle(GetAllEmployeesFromUserQuery query, CancellationToken cancellationToken)
        {
            var employees = await _employeeRepository.GetAllFromUserAsync(query.UserId, query.Page, query.Size, cancellationToken);
            return new GetAllEmployeesFromUserDto() { Data = await employees.BuildAdapter().AdaptToTypeAsync<EmployeeDto[]>(), TotalRecords = await _employeeRepository.GetAllFromUserCountAsync(query.UserId, cancellationToken) };
        }
    }
}
