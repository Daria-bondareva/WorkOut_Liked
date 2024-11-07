using Application.DTO.Responses;
using Application.Queries.WorkOut_Q;
using AutoMapper;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetAllWorkOutsQueryHandler : IRequestHandler<GetAllWorkOutsQuery, IEnumerable<WorkOutResponse>>
{
    private readonly LikedContext _context;
    private readonly IMapper _mapper;

    public GetAllWorkOutsQueryHandler(LikedContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<WorkOutResponse>> Handle(GetAllWorkOutsQuery request, CancellationToken cancellationToken)
    {
        var workouts = await _context.WorkOuts.ToListAsync(cancellationToken);
        return _mapper.Map<IEnumerable<WorkOutResponse>>(workouts);
    }
}
