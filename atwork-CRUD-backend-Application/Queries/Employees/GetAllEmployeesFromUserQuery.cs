using atwork_CRUD_backend_Application.DTOs.Employees;

namespace atwork_CRUD_backend_Application.Queries.Employees
{
    public class GetAllEmployeesFromUserQuery : IQuery<GetAllEmployeesFromUserDto>
    {
        public Guid UserId { get; }
        public int Page { get; }
        public int Size { get; }

        public GetAllEmployeesFromUserQuery(Guid userId, int page, int size)
        {
            UserId = userId;
            Page = page;
            Size = size;
        }
    }
}
