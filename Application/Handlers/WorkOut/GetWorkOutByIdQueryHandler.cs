using Application.DTO.Responses;
using Application.Queries.WorkOut_Q;
using AutoMapper;
using Infrastructure;
using MediatR;

public class GetWorkOutByIdQueryHandler : IRequestHandler<GetWorkOutByIdQuery, WorkOutResponse>
{
    private readonly LikedContext _context;
    private readonly IMapper _mapper;

    public GetWorkOutByIdQueryHandler(LikedContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<WorkOutResponse> Handle(GetWorkOutByIdQuery request, CancellationToken cancellationToken)
    {
        var workout = await _context.WorkOuts.FindAsync(new object[] { request.Id }, cancellationToken);
        if (workout == null) throw new KeyNotFoundException("WorkOut not found.");

        return _mapper.Map<WorkOutResponse>(workout);
    }
}
