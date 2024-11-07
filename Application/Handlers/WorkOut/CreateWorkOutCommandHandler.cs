using Application.Commands.WorkOut;
using AutoMapper;
using Domain.Entites;
using Infrastructure;
using MediatR;

public class CreateWorkOutCommandHandler : IRequestHandler<CreateWorkOutCommand, int>
{
    private readonly LikedContext _context;
    private readonly IMapper _mapper;

    public CreateWorkOutCommandHandler(LikedContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateWorkOutCommand request, CancellationToken cancellationToken)
    {
        var workout = _mapper.Map<WorkOut>(request);
        _context.WorkOuts.Add(workout);
        await _context.SaveChangesAsync(cancellationToken);

        return workout.Id;
    }
}
