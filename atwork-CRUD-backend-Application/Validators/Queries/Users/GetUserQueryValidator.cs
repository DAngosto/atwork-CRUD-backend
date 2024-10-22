using atwork_CRUD_backend_Application.Queries.Users;
using FluentValidation;

namespace atwork_CRUD_backend_Application.Validators.Queries.Users
{
    public class GetUserQueryValidator : AbstractValidator<GetUserQuery>
    {
        public GetUserQueryValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("userId parameter was empty in the request");
        }
    }
}
