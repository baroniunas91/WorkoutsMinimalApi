using FluentValidation;
using WorkoutsMinimalApi.Models.Requests;

namespace WorkoutsMinimalApi.Validators;

public class WorkoutUpdateValidator : AbstractValidator<WorkoutUpdateRequest>
{
    public WorkoutUpdateValidator()
    {
        RuleFor(x => x.Date).Must(ValidDate);
    }

    private static bool ValidDate(DateTime dateTime)
    {
        return dateTime >= new DateTime(1970, 1, 1);
    }
}