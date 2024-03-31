namespace WorkoutsMinimalApi.Models.Responses;

public class WorkoutCalenderResponse
{
    public string Date { get; set; }
    public IEnumerable<WorkoutHistoryResponse> Workouts { get; set; }
}