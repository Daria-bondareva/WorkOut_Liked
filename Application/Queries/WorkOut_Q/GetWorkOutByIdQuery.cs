using Application.DTO.Responses;
using MediatR;

namespace Application.Queries.WorkOut_Q
{
    public record GetWorkOutByIdQuery(int Id) : IRequest<WorkOutResponse>;
}
