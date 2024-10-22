using atwork_CRUD_backend_Application.DTOs.Dashboard;
using atwork_CRUD_backend_Domain.Entities;
using atwork_CRUD_backend_Domain.Repositories;
using MediatR;

namespace atwork_CRUD_backend_Application.Queries.Dashboard
{
    public class GetDashboardDataQueryHandler : IRequestHandler<GetDashboardDataQuery, DashboardDataDto>
    {
        private readonly IUserRepository _userRepository;

        public GetDashboardDataQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<DashboardDataDto> Handle(GetDashboardDataQuery query, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(query.UserId, cancellationToken);
            if (user is null)
                throw new KeyNotFoundException(UserErrors.NotFoundById(query.UserId));
            
            return new DashboardDataDto()
            {
                NumberOfEmployees = user.Employees.Count,
                ProductivityScoreAverage = user.Employees.Average(e => e.ProductivityScore),
                WellnessScoreAverage = user.Employees.Average(e => e.WellnessScore),
            };
        }
    }
}
