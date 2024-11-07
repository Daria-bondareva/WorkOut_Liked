using Application.Commands.WorkOut;
using Infrastructure;
using MediatR;

public class DeleteWorkOutCommandHandler : IRequestHandler<DeleteWorkOutCommand>
{
    private readonly LikedContext _context;

    public DeleteWorkOutCommandHandler(LikedContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteWorkOutCommand request, CancellationToken cancellationToken)
    {
        var workout = await _context.WorkOuts.FindAsync(new object[] { request.Id }, cancellationToken);

        if (workout == null)
        {
            throw new KeyNotFoundException("WorkOut not found.");
        }

        _context.WorkOuts.Remove(workout);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
