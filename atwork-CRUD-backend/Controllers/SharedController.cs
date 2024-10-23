using atwork_CRUD_backend_Application.DTOs.Shared;
using atwork_CRUD_backend_Application.Exceptions;
using atwork_CRUD_backend_Application.Queries.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace atwork_CRUD_backend.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class SharedController : ControllerBase
    {
        private readonly ILogger<SharedController> _logger;
        private readonly IMediator _mediator;

        public SharedController(ILogger<SharedController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("GetAllCountries")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        [ProducesResponseType(typeof(CountryDto[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ExceptionResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ExceptionResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ExceptionResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAllCountries()
        {
            var query = new GetAllCountriesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
