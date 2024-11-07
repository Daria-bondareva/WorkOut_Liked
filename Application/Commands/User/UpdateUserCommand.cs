using MediatR;

namespace Application.Commands.User
{

    public record UpdateUserCommand(int Id, string UserName, string Email, string Password) : IRequest;
}
