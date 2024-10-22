using atwork_CRUD_backend_Application.DTOs.Users;

namespace atwork_CRUD_backend_Application.Queries.Users
{
    public class GetUserQuery : IQuery<UserDto>
    {
        public Guid UserId { get; }

        public GetUserQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
