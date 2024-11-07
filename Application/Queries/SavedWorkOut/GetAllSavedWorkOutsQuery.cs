using Application.DTO.Responses;
using MediatR;
using System.Collections.Generic;

namespace Application.Queries.SavedWorkOut
{
    public record GetAllSavedWorkoutsQuery() : IRequest<IEnumerable<SavedWorkoutResponse>>;
}
