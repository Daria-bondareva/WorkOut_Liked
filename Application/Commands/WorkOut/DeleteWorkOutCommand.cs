using MediatR;

namespace Application.Commands.WorkOut
{
    public record DeleteWorkOutCommand(int Id) : IRequest;
}
