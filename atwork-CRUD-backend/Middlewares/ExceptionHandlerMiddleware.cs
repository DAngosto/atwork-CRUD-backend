using atwork_CRUD_backend_Application.Exceptions;

namespace atwork_CRUD_backend.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            _logger.LogError(exception, "Unexpected error ocurred.");

            ExceptionResponse response = exception switch
            {
                ValidationException _ => new ExceptionResponse(System.Net.HttpStatusCode.BadRequest, $"Invalid request error ocurred: {exception.Message}"),
                KeyNotFoundException _ => new ExceptionResponse(System.Net.HttpStatusCode.NotFound, $"Not found error ocurred: {exception.Message}"),
                UnauthorizedAccessException _ => new ExceptionResponse(System.Net.HttpStatusCode.Unauthorized, $"Unauthorized access error ocurred: {exception.Message}"),
                _ => new ExceptionResponse(System.Net.HttpStatusCode.InternalServerError, $"Unexpected error ocurred: {exception.Message}"),
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)response.StatusCode;
            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
