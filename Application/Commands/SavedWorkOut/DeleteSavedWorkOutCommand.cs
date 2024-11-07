using MediatR;

namespace Application.Commands.SavedWorkOut
{
    public record DeleteSavedWorkoutCommand(int Id) : IRequest;
}
