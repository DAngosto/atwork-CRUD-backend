using atwork_CRUD_backend_Application.Commands.Auth;
using atwork_CRUD_backend_Application.DTOs;
using atwork_CRUD_backend_Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace atwork_CRUD_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IMediator _mediator;

        public AuthController(ILogger<AuthController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ExceptionResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ExceptionResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ExceptionResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var command = new LoginCommand(request);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("register")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ExceptionResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ExceptionResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ExceptionResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var command = new RegisterCommand(request);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
