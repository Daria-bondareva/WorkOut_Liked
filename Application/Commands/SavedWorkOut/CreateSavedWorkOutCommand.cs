using MediatR;


namespace Application.Commands.SavedWorkOut
{
    public record CreateSavedWorkoutCommand(int UserId, int WorkoutId, DateTime SavedDate, string Notes) : IRequest<int>;
    
}
