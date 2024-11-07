using Application.Commands.User;
using AutoMapper;
using Domain.Entites;
using Infrastructure;
using MediatR;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
{
    private readonly LikedContext _context;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(LikedContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(request);
        _context.Users.Add(user);
        await _context.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}
