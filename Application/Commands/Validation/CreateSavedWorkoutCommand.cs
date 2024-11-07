using FluentValidation;
using Application.Commands.SavedWorkOut;

public class CreateSavedWorkoutCommandValidator : AbstractValidator<CreateSavedWorkoutCommand>
{
    public CreateSavedWorkoutCommandValidator()
    {
        RuleFor(x => x.UserId).GreaterThan(0).WithMessage("UserId must be greater than 0.");
        RuleFor(x => x.WorkoutId).GreaterThan(0).WithMessage("WorkoutId must be greater than 0.");
        RuleFor(x => x.SavedDate).NotEmpty().WithMessage("SavedDate is required.");
        RuleFor(x => x.Notes).MaximumLength(500).WithMessage("Notes cannot exceed 500 characters.");
    }
}
