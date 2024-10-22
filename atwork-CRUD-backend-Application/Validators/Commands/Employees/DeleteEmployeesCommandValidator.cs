using atwork_CRUD_backend_Application.Commands.Employees;
using FluentValidation;

namespace atwork_CRUD_backend_Application.Validators.Commands.Employees
{
    public class DeleteEmployeesCommandValidator : AbstractValidator<DeleteEmployeesCommand>
    {
        public DeleteEmployeesCommandValidator()
        {
            RuleFor(x => x.Request.EmployeeIds)
                .NotEmpty().WithMessage("employeeIds parameter was empty in the request");
        }
    }
}
