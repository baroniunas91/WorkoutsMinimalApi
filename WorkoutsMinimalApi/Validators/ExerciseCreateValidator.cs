using FluentValidation;
using WorkoutsMinimalApi.Models.Requests;

namespace WorkoutsMinimalApi.Validators;

public class ExerciseCreateValidator : AbstractValidator<ExerciseCreateRequest>
{
    public ExerciseCreateValidator()
    {
        RuleFor(x => x.WorkoutId).NotEmpty().GreaterThan(0);
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Sets).GreaterThan(0);
        RuleFor(x => x.Reps).GreaterThan(0);
        RuleFor(x => x.Duration).GreaterThan(0);
    }
}