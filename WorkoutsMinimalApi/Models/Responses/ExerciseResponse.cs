namespace WorkoutsMinimalApi.Models.Responses;

public class ExerciseResponse
{
    public string Name { get; set; }
    public int Sets { get; set; }
    public int Reps { get; set; }
    public string Duration { get; set; }
}