using atwork_CRUD_backend_Application.DTOs;

namespace atwork_CRUD_backend_Application.Queries.Employee
{
    public class GetAllEmployeesQuery : IQuery<GetAllEmployeesDto>
    {
        public int Page { get; }
        public int Size { get; }

        public GetAllEmployeesQuery(int page, int size)
        {
            Page = page;
            Size = size;
        }
    }
}
