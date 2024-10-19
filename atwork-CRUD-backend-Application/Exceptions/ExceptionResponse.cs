using System.Net;

namespace atwork_CRUD_backend_Application.Exceptions
{
    public record ExceptionResponse(HttpStatusCode StatusCode, string Message);
}
