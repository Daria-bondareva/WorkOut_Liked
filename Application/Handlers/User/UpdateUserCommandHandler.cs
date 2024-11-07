using Application.Commands.User;
using AutoMapper;
using Infrastructure;
using MediatR;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
{
    private readonly LikedContext _context;
    private readonly IMapper _mapper;

    public UpdateUserCommandHandler(LikedContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FindAsync(new object[] { request.Id }, cancellationToken);
        if (user == null) throw new KeyNotFoundException("User not found.");

        _mapper.Map(request, user);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
