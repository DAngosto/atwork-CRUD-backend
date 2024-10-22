using atwork_CRUD_backend_Application.Commands.Employees;
using atwork_CRUD_backend_Application.DTOs.Employees;
using atwork_CRUD_backend_Application.Exceptions;
using atwork_CRUD_backend_Application.Queries.Employees;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace atwork_CRUD_backend.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly ILogger<EmployeesController> _logger;
        private readonly IMediator _mediator;

        public EmployeesController(ILogger<EmployeesController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(EmployeeDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ExceptionResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ExceptionResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ExceptionResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetEmployee(Guid employeeId)
        {
            var query = new GetEmployeeQuery(employeeId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("GetAllFromUser")]
        [ProducesResponseType(typeof(GetAllEmployeesFromUserDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ExceptionResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ExceptionResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ExceptionResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAll(Guid userId, int page = 0, int size = 10)
        {
            var query = new GetAllEmployeesFromUserQuery(userId, page, size);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(EmployeeDto), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ExceptionResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ExceptionResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ExceptionResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeRequest request)
        {
            var command = new CreateEmployeeCommand(request);
            var newEmployeeId = await _mediator.Send(command); 

            var query = new GetEmployeeQuery(newEmployeeId);
            var employeeDetails = await _mediator.Send(query);

            return CreatedAtAction(
                actionName: nameof(GetEmployee),
                routeValues: new { employeeId = newEmployeeId },
                value: employeeDetails
            );
        }

        [HttpPut]
        [ProducesResponseType(typeof(EmployeeDto), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ExceptionResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ExceptionResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ExceptionResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Update([FromBody] UpdateEmployeeRequest request)
        {
            var command = new UpdateEmployeeCommand(request);
            var newEmployeeId = await _mediator.Send(command);

            var query = new GetEmployeeQuery(newEmployeeId);
            var employeeDetails = await _mediator.Send(query);

            return CreatedAtAction(
                actionName: nameof(GetEmployee),
                routeValues: new { employeeId = newEmployeeId },
                value: employeeDetails
            );
        }
    }
}
