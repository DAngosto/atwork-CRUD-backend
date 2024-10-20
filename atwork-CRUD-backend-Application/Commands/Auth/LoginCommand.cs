using atwork_CRUD_backend_Application.DTOs;

namespace atwork_CRUD_backend_Application.Commands.Auth
{
    public class LoginCommand : ICommand<LoginDto>
    {
        public LoginRequest LoginRequest { get; }

        public LoginCommand(LoginRequest loginRequest)
        {
            LoginRequest = loginRequest;
        }
    }
}
