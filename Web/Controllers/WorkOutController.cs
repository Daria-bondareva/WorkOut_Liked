using Application.Commands.WorkOut;
using Application.DTO.Responses;
using Application.Queries.WorkOut_Q;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkOutController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WorkOutController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkOutResponse>>> GetAllWorkouts(CancellationToken cancellationToken)
        {
            var workouts = await _mediator.Send(new GetAllWorkOutsQuery(), cancellationToken);
            return Ok(workouts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WorkOutResponse>> GetWorkOutById(int id, CancellationToken cancellationToken)
        {
            var workout = await _mediator.Send(new GetWorkOutByIdQuery(id), cancellationToken);
            return workout != null ? Ok(workout) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateWorkOut([FromBody] CreateWorkOutCommand command, CancellationToken cancellationToken)
        {
            var workoutId = await _mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(GetWorkOutById), new { id = workoutId }, workoutId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWorkOut(int id, [FromBody] UpdateWorkOutCommand command, CancellationToken cancellationToken)
        {
            if (id != command.Id)
                return BadRequest();

            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkOut(int id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteWorkOutCommand(id), cancellationToken);
            return NoContent();
        }
    }
}
