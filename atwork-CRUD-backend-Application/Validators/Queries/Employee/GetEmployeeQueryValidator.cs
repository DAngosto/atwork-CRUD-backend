using atwork_CRUD_backend_Application.Queries.Employee;
using FluentValidation;

namespace atwork_CRUD_backend_Application.Validators.Queries.Employee
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
