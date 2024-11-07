using FluentValidation;
using Application.Commands.WorkOut;

public class CreateWorkOutCommandValidator : AbstractValidator<CreateWorkOutCommand>
{
    public CreateWorkOutCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.")
                            .MaximumLength(200).WithMessage("Name cannot exceed 200 characters.");
        RuleFor(x => x.Description).MaximumLength(1000).WithMessage("Description cannot exceed 1000 characters.");
        RuleFor(x => x.TypeId).GreaterThan(0).WithMessage("TypeId must be greater than 0.");
        RuleFor(x => x.CategoryId).GreaterThan(0).WithMessage("CategoryId must be greater than 0.");
        RuleFor(x => x.TrainingDuration).NotEmpty().WithMessage("TrainingDuration is required.");
        RuleFor(x => x.Price).NotNull().WithMessage("Price is required.");
    }
}
