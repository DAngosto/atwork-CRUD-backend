using FluentValidation;
using MediatR;

namespace atwork_CRUD_backend_Application.Validators
{
    public sealed class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : class, IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!_validators.Any())
            {
                return await next();
            }

            var context = new ValidationContext<TRequest>(request);
            var validationTasks = _validators.Select(x => x.ValidateAsync(context));
            var validationResults = await Task.WhenAll(validationTasks);

            var errorsDictionary = validationResults
                .SelectMany(x => x.Errors)
                .Where(x => x is not null)
                .GroupBy(x => x.PropertyName,
                x => x.ErrorMessage,
                (propertyName, errorMessages) => new
                {
                    Key = propertyName,
                    Values = errorMessages.Distinct().ToArray()
                })
                .ToDictionary(group => group.Key, group => group.Values);

            if (errorsDictionary.Count > 0)
            {
                throw new Exceptions.ValidationException(errorsDictionary);
            }

            return await next();
        }
    }
}
