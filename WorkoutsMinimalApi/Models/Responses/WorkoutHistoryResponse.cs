namespace WorkoutsMinimalApi.Models.Responses;

public class WorkoutHistoryResponse
{
    public string Title { get; set; }
    public string Description { get; set; }
    public BaseWorkoutSummaryResponse Summary { get; set; }
    public IEnumerable<ExerciseResponse> Exercises { get; set; }
}