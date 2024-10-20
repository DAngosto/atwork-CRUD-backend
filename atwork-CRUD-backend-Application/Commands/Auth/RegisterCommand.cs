using atwork_CRUD_backend_Application.DTOs;

namespace atwork_CRUD_backend_Application.Commands.Auth
{
    public class RegisterCommand : ICommand<string>
    {
        public RegisterRequest RegisterRequest { get; }

        public RegisterCommand(RegisterRequest registerRequest)
        {
            RegisterRequest = registerRequest;
        }
    }
}
