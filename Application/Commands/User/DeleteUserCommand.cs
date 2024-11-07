using MediatR;

namespace Application.Commands.User
{
    public record DeleteUserCommand(int Id) : IRequest;
}
