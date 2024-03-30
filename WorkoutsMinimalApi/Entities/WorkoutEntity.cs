using WorkoutsMinimalApi.Interfaces;

namespace WorkoutsMinimalApi.Entities;

public class WorkoutEntity : IEntity
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public virtual ICollection<ExerciseEntity> Exercises { get; set; }
}