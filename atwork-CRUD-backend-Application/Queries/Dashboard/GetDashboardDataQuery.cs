using atwork_CRUD_backend_Application.DTOs.Dashboard;

namespace atwork_CRUD_backend_Application.Queries.Dashboard
{
    public class GetDashboardDataQuery : IQuery<DashboardDataDto>
    {
        public Guid UserId { get; }

        public GetDashboardDataQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
