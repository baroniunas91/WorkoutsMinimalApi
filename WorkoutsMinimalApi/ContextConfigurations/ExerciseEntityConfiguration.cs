using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkoutsMinimalApi.Entities;

namespace WorkoutsMinimalApi.ContextConfigurations;

public class ExerciseEntityConfiguration : IEntityTypeConfiguration<ExerciseEntity>
{
    public void Configure(EntityTypeBuilder<ExerciseEntity> builder)
    {
        builder.ToTable("exercises");
        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.Name).HasColumnName("name").HasColumnType("varchar(255)");
        builder.Property(e => e.Sets).HasColumnName("sets");
        builder.Property(e => e.Reps).HasColumnName("reps");
        builder.Property(e => e.Duration).HasColumnName("duration");
        builder.HasOne(e => e.Workout)
            .WithMany(x => x.Exercises)
            .HasForeignKey(x => x.WorkoutId);
    }
}