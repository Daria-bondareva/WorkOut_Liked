using Application.Commands.SavedWorkOut;
using Infrastructure;
using MediatR;

public class DeleteSavedWorkoutCommandHandler : IRequestHandler<DeleteSavedWorkoutCommand>
{
    private readonly LikedContext _context;

    public DeleteSavedWorkoutCommandHandler(LikedContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteSavedWorkoutCommand request, CancellationToken cancellationToken)
    {
        var savedWorkout = await _context.SavedWorkouts.FindAsync(new object[] { request.Id }, cancellationToken);

        if (savedWorkout == null)
            throw new KeyNotFoundException("Saved workout not found.");

        _context.SavedWorkouts.Remove(savedWorkout);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value; 
    }
}
