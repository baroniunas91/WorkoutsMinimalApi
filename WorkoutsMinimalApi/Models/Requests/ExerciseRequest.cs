namespace WorkoutsMinimalApi.Models.Requests;

public class ExerciseRequest
{
    public int WorkoutId { get; set; }
    public string Name { get; set; }
    public int Sets { get; set; }
    public int Reps { get; set; }
    public int Duration { get; set; }
}