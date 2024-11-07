using Application.Commands.SavedWorkOut;
using AutoMapper;
using Infrastructure;
using MediatR;

public class UpdateSavedWorkoutCommandHandler : IRequestHandler<UpdateSavedWorkoutCommand>
{
    private readonly LikedContext _context;
    private readonly IMapper _mapper;

    public UpdateSavedWorkoutCommandHandler(LikedContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateSavedWorkoutCommand request, CancellationToken cancellationToken)
    {
        var savedWorkout = await _context.SavedWorkouts.FindAsync(new object[] { request.Id }, cancellationToken);
        if (savedWorkout == null) throw new KeyNotFoundException("Saved workout not found.");

        _mapper.Map(request, savedWorkout);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
