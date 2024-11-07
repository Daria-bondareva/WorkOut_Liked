using Application.Commands.WorkOut;
using AutoMapper;
using Infrastructure;
using MediatR;

public class UpdateWorkOutCommandHandler : IRequestHandler<UpdateWorkOutCommand>
{
    private readonly LikedContext _context;
    private readonly IMapper _mapper;

    public UpdateWorkOutCommandHandler(LikedContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateWorkOutCommand request, CancellationToken cancellationToken)
    {
        var workout = await _context.WorkOuts.FindAsync(new object[] { request.Id }, cancellationToken);
        if (workout == null) throw new KeyNotFoundException("WorkOut not found.");

        _mapper.Map(request, workout);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
