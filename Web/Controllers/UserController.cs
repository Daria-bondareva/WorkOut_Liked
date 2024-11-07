
using Application.Commands.User;
using Application.DTO.Responses;
using Application.Queries.User_Q;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResponse>>> GetAllUsers(CancellationToken cancellationToken)
        {
            var users = await _mediator.Send(new GetAllUsersQuery(), cancellationToken);
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponse>> GetUserById(int id, CancellationToken cancellationToken)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(id), cancellationToken);
            return user != null ? Ok(user) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateUser([FromBody] CreateUserCommand command, CancellationToken cancellationToken)
        {
            var userId = await _mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(GetUserById), new { id = userId }, userId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserCommand command, CancellationToken cancellationToken)
        {
            if (id != command.Id)
                return BadRequest();

            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteUserCommand(id), cancellationToken);
            return NoContent();
        }
    }
}
