using Application.Commands.SavedWorkOut;
using Application.DTO.Responses;
using Application.Queries.SavedWorkOut;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SavedWorkoutController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SavedWorkoutController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SavedWorkoutResponse>>> GetAllSavedWorkouts(CancellationToken cancellationToken)
        {
            var savedWorkouts = await _mediator.Send(new GetAllSavedWorkoutsQuery(), cancellationToken);
            return Ok(savedWorkouts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SavedWorkoutResponse>> GetSavedWorkoutById(int id, CancellationToken cancellationToken)
        {
            var savedWorkout = await _mediator.Send(new GetSavedWorkoutByIdQuery(id), cancellationToken);
            return savedWorkout != null ? Ok(savedWorkout) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateSavedWorkout([FromBody] CreateSavedWorkoutCommand command, CancellationToken cancellationToken)
        {
            var savedWorkoutId = await _mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(GetSavedWorkoutById), new { id = savedWorkoutId }, savedWorkoutId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSavedWorkout(int id, [FromBody] UpdateSavedWorkoutCommand command, CancellationToken cancellationToken)
        {
            if (id != command.Id)
                return BadRequest();

            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSavedWorkout(int id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteSavedWorkoutCommand(id), cancellationToken);
            return NoContent();
        }
    }
}
