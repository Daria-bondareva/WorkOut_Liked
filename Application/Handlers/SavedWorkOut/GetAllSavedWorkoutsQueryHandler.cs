using Application.DTO.Responses;
using Application.Queries.SavedWorkOut;
using AutoMapper;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetAllSavedWorkoutsQueryHandler : IRequestHandler<GetAllSavedWorkoutsQuery, IEnumerable<SavedWorkoutResponse>>
{
    private readonly LikedContext _context;
    private readonly IMapper _mapper;

    public GetAllSavedWorkoutsQueryHandler(LikedContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<SavedWorkoutResponse>> Handle(GetAllSavedWorkoutsQuery request, CancellationToken cancellationToken)
    {
        var savedWorkouts = await _context.SavedWorkouts.ToListAsync(cancellationToken);
        return _mapper.Map<IEnumerable<SavedWorkoutResponse>>(savedWorkouts);
    }
}
