using atwork_CRUD_backend_Application.Queries.Dashboard;
using FluentValidation;

namespace atwork_CRUD_backend_Application.Validators.Queries.Dashboard
{
    public class GetDashboardDataQueryValidator : AbstractValidator<GetDashboardDataQuery>
    {
        public GetDashboardDataQueryValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("userId parameter was empty in the request");
        }
    }
}
