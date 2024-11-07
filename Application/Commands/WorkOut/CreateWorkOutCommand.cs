using Domain.ValueObjects;
using MediatR;

namespace Application.Commands.WorkOut
{
    public record CreateWorkOutCommand(string Name, string Description, int TypeId, int CategoryId, string TrainingDuration, Price Price) : IRequest<int>;
}
