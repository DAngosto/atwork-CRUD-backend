using atwork_CRUD_backend_Application.DTOs.Dashboard;
using atwork_CRUD_backend_Application.DTOs.Shared;

namespace atwork_CRUD_backend_Application.Queries.Shared
{
    public class GetAllCountriesQuery : IQuery<CountryDto[]>
    {
        public GetAllCountriesQuery()
        {
        }
    }
}
