using Application.DTO.Responses;
using Application.Queries.SavedWorkOut;
using AutoMapper;
using Infrastructure;
using MediatR;

public class GetSavedWorkoutByIdQueryHandler : IRequestHandler<GetSavedWorkoutByIdQuery, SavedWorkoutResponse>
{
    private readonly LikedContext _context;
    private readonly IMapper _mapper;

    public GetSavedWorkoutByIdQueryHandler(LikedContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<SavedWorkoutResponse> Handle(GetSavedWorkoutByIdQuery request, CancellationToken cancellationToken)
    {
        var savedWorkout = await _context.SavedWorkouts.FindAsync(new object[] { request.Id }, cancellationToken);
        if (savedWorkout == null) throw new KeyNotFoundException("Saved workout not found.");

        return _mapper.Map<SavedWorkoutResponse>(savedWorkout);
    }
}
