using WorkoutsMinimalApi.Interfaces;

namespace WorkoutsMinimalApi.Entities;

public class ExerciseEntity : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Sets { get; set; }
    public int Reps { get; set; }
    public int Duration { get; set; }
    public virtual WorkoutEntity Workout { get; set; }
    public int WorkoutId { get; set; }
}