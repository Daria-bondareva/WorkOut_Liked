using Application.DTO.Responses;
using MediatR;
using System.Collections.Generic;

namespace Application.Queries.WorkOut_Q
{
    public record GetAllWorkOutsQuery() : IRequest<IEnumerable<WorkOutResponse>>;
}
