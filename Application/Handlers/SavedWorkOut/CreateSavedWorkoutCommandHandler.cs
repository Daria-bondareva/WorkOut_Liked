using Application.Commands.SavedWorkOut;
using AutoMapper;
using Domain.Entites;
using Infrastructure;
using MediatR;

public class CreateSavedWorkoutCommandHandler : IRequestHandler<CreateSavedWorkoutCommand, int>
{
    private readonly LikedContext _context;
    private readonly IMapper _mapper;

    public CreateSavedWorkoutCommandHandler(LikedContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateSavedWorkoutCommand request, CancellationToken cancellationToken)
    {
        var savedWorkout = _mapper.Map<SavedWorkout>(request);
        _context.SavedWorkouts.Add(savedWorkout);
        await _context.SaveChangesAsync(cancellationToken);

        return savedWorkout.Id;
    }
}
