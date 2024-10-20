using atwork_CRUD_backend_Application.Commands.Auth;
using FluentValidation;

namespace atwork_CRUD_backend_Application.Validators.Commands.Auth
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(x => x.LoginRequest.Email)
                .NotEmpty().WithMessage("email parameter was empty in the request");

            RuleFor(x => x.LoginRequest.Password)
                .NotEmpty().WithMessage("password parameter was empty in the request");
        }
    }
}
