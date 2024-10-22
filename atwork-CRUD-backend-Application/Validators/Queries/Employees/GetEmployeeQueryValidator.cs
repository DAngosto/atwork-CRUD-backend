using atwork_CRUD_backend_Application.Queries.Employees;
using FluentValidation;

namespace atwork_CRUD_backend_Application.Validators.Queries.Employees
{
    public class GetEmployeeQueryValidator : AbstractValidator<GetEmployeeQuery>
    {
        public GetEmployeeQueryValidator()
        {
            RuleFor(x => x.EmployeeId)
                .NotEmpty().WithMessage("employeeId parameter was empty in the request");
        }
    }
}
