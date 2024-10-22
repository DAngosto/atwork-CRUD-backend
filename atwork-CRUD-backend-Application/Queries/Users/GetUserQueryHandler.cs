using atwork_CRUD_backend_Application.DTOs.Users;
using atwork_CRUD_backend_Domain.Entities;
using atwork_CRUD_backend_Domain.Repositories;
using Mapster;
using MediatR;

namespace atwork_CRUD_backend_Application.Queries.Users
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;

        public GetUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> Handle(GetUserQuery query, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(query.UserId, cancellationToken);
            if (user is null)
                throw new KeyNotFoundException(UserErrors.NotFoundById(query.UserId));
            return await user.BuildAdapter().AdaptToTypeAsync<UserDto>();
        }
    }
}
