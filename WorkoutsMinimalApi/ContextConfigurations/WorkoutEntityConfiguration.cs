using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkoutsMinimalApi.Entities;

namespace WorkoutsMinimalApi.ContextConfigurations;

public class WorkoutEntityConfiguration : IEntityTypeConfiguration<WorkoutEntity>
{
    public void Configure(EntityTypeBuilder<WorkoutEntity> builder)
    {
        builder.ToTable("workouts");
        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.Title).HasColumnName("title").HasColumnType("varchar(255)");
        builder.Property(e => e.Description).HasColumnName("description").HasColumnType("varchar(255)");
        builder.HasMany(x => x.Exercises)
            .WithOne(x => x.Workout)
            .HasForeignKey(x => x.WorkoutId);
    }
}