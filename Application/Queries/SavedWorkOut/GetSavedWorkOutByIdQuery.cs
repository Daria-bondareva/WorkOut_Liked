using Application.DTO.Responses;
using MediatR;

namespace Application.Queries.SavedWorkOut
{
    public record GetSavedWorkoutByIdQuery(int Id) : IRequest<SavedWorkoutResponse>;
}
