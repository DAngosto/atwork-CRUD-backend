using atwork_CRUD_backend_Application.Commands.Employees;
using FluentValidation;
using System.Net.Mail;

namespace atwork_CRUD_backend_Application.Validators.Commands.Employees
{
    public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandValidator()
        {
            RuleFor(x => x.Request.UserId)
                .NotEmpty().WithMessage("userId parameter was empty in the request");

            RuleFor(x => x.Request.FirstName)
                .NotEmpty().WithMessage("firstName parameter was empty in the request");

            RuleFor(x => x.Request.LastName)
                .NotEmpty().WithMessage("lastName parameter was empty in the request");

            RuleFor(x => x.Request.Phone)
                .NotEmpty().WithMessage("phone parameter was empty in the request");

            RuleFor(x => x.Request.Address)
                .NotEmpty().WithMessage("address parameter was empty in the request");

            RuleFor(x => x.Request.Country)
                .NotEmpty().WithMessage("country parameter was empty in the request");

            RuleFor(x => x.Request.Email)
                .NotEmpty().WithMessage("email parameter was empty in the request")
                .Must(IsValidEmail).WithMessage("email parameter provided is not a valid email");
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
