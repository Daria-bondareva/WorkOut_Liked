using Application.DTO.Responses;
using Application.Queries.User_Q;
using AutoMapper;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserResponse>>
{
    private readonly LikedContext _context;
    private readonly IMapper _mapper;

    public GetAllUsersQueryHandler(LikedContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserResponse>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _context.Users.ToListAsync(cancellationToken);
        return _mapper.Map<IEnumerable<UserResponse>>(users);
    }
}
