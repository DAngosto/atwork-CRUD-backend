using MediatR;

namespace atwork_CRUD_backend_Application.Commands
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}
