using FluentValidation;
using Application.Commands.User;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName is required.")
                                 .MaximumLength(100).WithMessage("UserName cannot exceed 100 characters.");
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.")
                             .EmailAddress().WithMessage("Invalid email format.");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required.")
                                .MinimumLength(6).WithMessage("Password must be at least 6 characters.");
    }
}
