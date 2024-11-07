using MediatR;


namespace Application.Commands.User
{
    public record CreateUserCommand(string UserName, string Email, string Password) : IRequest<int>;
}
