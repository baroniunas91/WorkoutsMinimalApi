using FluentValidation;
using WorkoutsMinimalApi.Models.Requests;

namespace WorkoutsMinimalApi.Validators;

public class WorkoutCreateValidator : AbstractValidator<WorkoutCreateRequest>
{
    public WorkoutCreateValidator()
    {
        RuleFor(x => x.Title).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
    }
}