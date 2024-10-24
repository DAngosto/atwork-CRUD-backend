using atwork_CRUD_backend_Application.Commands.Employees;
using FluentValidation;

namespace atwork_CRUD_backend_Application.Validators.Commands.Employees
{
    public class DeleteEmployeeCommandValidator : AbstractValidator<DeleteEmployeeCommand>
    {
        public DeleteEmployeeCommandValidator()
        {
            RuleFor(x => x.EmployeeId)
                .NotEmpty().WithMessage("employeeId parameter was empty in the request");
        }
    }
}
