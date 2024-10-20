using atwork_CRUD_backend_Application.Commands.Auth;
using atwork_CRUD_backend_Domain.Entities;
using atwork_CRUD_backend_Domain.Repositories;
using atwork_CRUD_backend_Domain.Services;
using MediatR;

namespace atwork_CRUD_backend_Application.Queries.Employee
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;
        private readonly ITokenProviderService _tokenProviderService;

        public LoginCommandHandler(IUserRepository userRepository, IPasswordService passwordService, ITokenProviderService tokenProviderService)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
            _tokenProviderService = tokenProviderService;
        }

        public async Task<string> Handle(LoginCommand command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByUsernameAsync(command.LoginRequest.Username, cancellationToken);
            if (user is null)
                throw new UnauthorizedAccessException(UserErrors.InvalidUsernameOrPassword());

            bool verified = _passwordService.ValidatePassword(command.LoginRequest.Password, user.Password);
            if (!verified)
            {
                throw new UnauthorizedAccessException(UserErrors.InvalidUsernameOrPassword());
            }

            return _tokenProviderService.Create(user);
        }
    }
}
