using Application.DTO.Responses;
using MediatR;
using System.Collections.Generic;

namespace Application.Queries.User_Q
{
    public record GetAllUsersQuery() : IRequest<IEnumerable<UserResponse>>;
}
