using MediatR;

namespace Application.Commands.SavedWorkOut
{
    public record UpdateSavedWorkoutCommand(int Id, int UserId, int WorkoutId, DateTime SavedDate, string Notes) : IRequest;
}

