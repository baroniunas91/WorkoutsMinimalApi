using FluentValidation.Results;

namespace WorkoutsMinimalApi.Models.Responses;

public class ValidationFailureResponse
{
    public IEnumerable<string> Errors { get; set; } = Enumerable.Empty<string>();
}

public static class ValidationFailureMapper
{
    public static ValidationFailureResponse ToResponse(this IEnumerable<ValidationFailure> failures)
    {
        return new ValidationFailureResponse()
        {
            Errors = failures.Select(x => x.ErrorMessage)
        };
    }
}