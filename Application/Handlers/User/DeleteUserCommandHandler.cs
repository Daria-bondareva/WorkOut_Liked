using Application.Commands.User;
using Infrastructure;
using MediatR;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly LikedContext _context;

    public DeleteUserCommandHandler(LikedContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FindAsync(new object[] { request.Id }, cancellationToken);

        if (user == null)
        {
            throw new KeyNotFoundException("User not found.");
        }

        _context.Users.Remove(user);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
