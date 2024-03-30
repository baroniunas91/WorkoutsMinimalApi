using Microsoft.EntityFrameworkCore;
using WorkoutsMinimalApi.ContextConfigurations;
using WorkoutsMinimalApi.Interfaces;

namespace WorkoutsMinimalApi.Services;

public class DbInitializer : IDbInitializer
{
    private readonly IServiceScopeFactory _scopeFactory;

    public DbInitializer(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }
    
    public void Initialize()
    {
        using var serviceScope = _scopeFactory.CreateScope();
        using var context = serviceScope.ServiceProvider.GetService<MyDbContext>();
        context.Database.Migrate();
    }
}