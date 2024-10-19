using MediatR;

namespace atwork_CRUD_backend_Application.Queries
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
