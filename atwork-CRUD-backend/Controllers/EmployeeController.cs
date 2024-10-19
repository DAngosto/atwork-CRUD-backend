using atwork_CRUD_backend_Application.DTOs;
using atwork_CRUD_backend_Application.Exceptions;
using atwork_CRUD_backend_Application.Queries.Employee;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace atwork_CRUD_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IMediator _mediator;

        public EmployeeController(ILogger<EmployeeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(EmployeeDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ExceptionResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ExceptionResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ExceptionResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetEmployee(Guid employeeId)
        {
            var query = new GetEmployeeQuery(employeeId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
