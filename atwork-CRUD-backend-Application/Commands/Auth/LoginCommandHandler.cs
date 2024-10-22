using atwork_CRUD_backend_Application.DTOs.Auth;
using atwork_CRUD_backend_Domain.Entities;
using atwork_CRUD_backend_Domain.Repositories;
using atwork_CRUD_backend_Domain.Services;
using MediatR;

namespace atwork_CRUD_backend_Application.Commands.Auth
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginDto>
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

        public async Task<LoginDto> Handle(LoginCommand command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(command.LoginRequest.Email, cancellationToken);
            if (user is null)
                throw new UnauthorizedAccessException(UserErrors.InvalidUsernameOrPassword());

            bool verified = _passwordService.ValidatePassword(command.LoginRequest.Password, user.Password);
            if (!verified)
            {
                throw new UnauthorizedAccessException(UserErrors.InvalidUsernameOrPassword());
            }

            return new LoginDto() { Token = _tokenProviderService.Create(user), UserId = user.Id };
        }
    }
}
