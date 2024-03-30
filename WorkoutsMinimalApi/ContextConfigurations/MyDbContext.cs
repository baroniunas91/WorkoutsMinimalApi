using Microsoft.EntityFrameworkCore;
using WorkoutsMinimalApi.Entities;

namespace WorkoutsMinimalApi.ContextConfigurations;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }
    
    public virtual DbSet<WorkoutEntity> Workouts { get; set; }
    public virtual DbSet<ExerciseEntity> Exercises { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new WorkoutEntityConfiguration());
        builder.ApplyConfiguration(new ExerciseEntityConfiguration());
    }
}