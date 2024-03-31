using System.Reflection;
using WorkoutsMinimalApi.Endpoints;
using WorkoutsMinimalApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddServices();
builder.Services.AddServicesFromAssemblies();
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());
builder.Services.AddValidators();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapWorkoutEndpoints();
app.MapExerciseEndpoints();

app.Run();
