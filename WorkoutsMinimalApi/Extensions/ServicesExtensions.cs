using Microsoft.EntityFrameworkCore;
using WorkoutsMinimalApi.ContextConfigurations;
using WorkoutsMinimalApi.Interfaces;
using WorkoutsMinimalApi.Services;

namespace WorkoutsMinimalApi.Extensions;

public static class ServicesExtensions
{
    public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Default");

        services.AddDbContext<MyDbContext>(o => 
            o.UseMySQL(connectionString));

        services.AddScoped<IDbInitializer, DbInitializer>();
    }
    
    public static void AddServices(this IServiceCollection services)
    {
        services.AddTransient<IWorkoutService, WorkoutService>();
        services.AddTransient<IExerciseService, ExerciseService>();
    }
    
    public static void AddServicesFromAssemblies(this IServiceCollection services)
    { 
        services.Scan(scan => scan
            .FromAssembliesOf(typeof(IRepository<>))
            .AddClasses(c => c.AssignableTo(typeof(IRepository<>)))
            .AsSelfWithInterfaces()
            .WithScopedLifetime());
        
        services.Scan(scan => scan
            .FromAssembliesOf(typeof(IEntityFilter<>))
            .AddClasses(c => c.AssignableTo(typeof(IEntityFilter<>)))
            .AsSelfWithInterfaces()
            .WithScopedLifetime());
    }
}