using atwork_CRUD_backend_Application.Commands.Auth;
using FluentValidation;
using System.Net.Mail;

namespace atwork_CRUD_backend_Application.Validators.Commands.Auth
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.RegisterRequest.Email)
                .NotEmpty().WithMessage("email parameter was empty in the request")
                .Must(IsValidEmail).WithMessage("email parameter provided is not a valid email");

            RuleFor(x => x.RegisterRequest.Password)
                .NotEmpty().WithMessage("password parameter was empty in the request");

        }

        private bool IsValidEmail(string email)
        {
            try
            {
                MailAddress mail = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
