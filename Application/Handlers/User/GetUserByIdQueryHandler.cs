using Application.DTO.Responses;
using Application.Queries.User_Q;
using AutoMapper;
using Infrastructure;
using MediatR;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserResponse>
{
    private readonly LikedContext _context;
    private readonly IMapper _mapper;

    public GetUserByIdQueryHandler(LikedContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<UserResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FindAsync(new object[] { request.Id }, cancellationToken);
        if (user == null) throw new KeyNotFoundException("User not found.");

        return _mapper.Map<UserResponse>(user);
    }
}
