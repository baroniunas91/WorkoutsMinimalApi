namespace WorkoutsMinimalApi.Models.Responses;

public class WorkoutSummaryResponse : BaseWorkoutSummaryResponse
{
    public int WorkoutId { get; set; }
}

public class BaseWorkoutSummaryResponse
{
    public int TotalSets { get; set; }
    public int TotalReps { get; set; }
    public string TotalDuration { get; set; }
}