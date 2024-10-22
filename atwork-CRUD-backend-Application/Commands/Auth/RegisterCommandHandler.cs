using atwork_CRUD_backend_Application.Commands.Auth;
using atwork_CRUD_backend_Application.DTOs;
using atwork_CRUD_backend_Domain.Entities;
using atwork_CRUD_backend_Domain.Repositories;
using atwork_CRUD_backend_Domain.Services;
using Mapster;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace atwork_CRUD_backend_Application.Queries.Employee
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;
        private readonly ITokenProviderService _tokenProviderService;

        public RegisterCommandHandler(IUserRepository userRepository, IPasswordService passwordService, ITokenProviderService tokenProviderService)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
            _tokenProviderService = tokenProviderService;
        }

        public async Task<RegisterDto> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            var newUser = new User()
            {
                Id = Guid.NewGuid(),
                Email = command.RegisterRequest.Email,
                Password = _passwordService.GeneratePasswordHash(command.RegisterRequest.Password),
                Company = command.RegisterRequest.Company,
                Phone = command.RegisterRequest.Phone
            };

            bool created = await _userRepository.AddAsync(newUser, true, cancellationToken);
            if (!created)
            {
                throw new Exception(UserErrors.UserCreationUnavailable());
            }

            return new RegisterDto() { Token = _tokenProviderService.Create(newUser) };
        }
    }
}
