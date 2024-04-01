namespace WorkoutsMinimalApi.Models.Responses;

public class WorkoutResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public IEnumerable<ExerciseResponse> Exercises { get; set; }
}