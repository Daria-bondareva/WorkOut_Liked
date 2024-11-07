using Application.DTO.Responses;
using MediatR;

namespace Application.Queries.User_Q
{
    public record GetUserByIdQuery(int Id) : IRequest<UserResponse>;
}
