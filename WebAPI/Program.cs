using ApplicationCore.Interfaces.Repository;
using BackendLab01;
using Infrastructure.Memory;
using Infrastructure.Memory.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddRazorPages();

builder.Services.AddTransient<IGenericGenerator<int>,IntGenerator>();

builder.Services.AddSingleton<IGenericRepository<Quiz, int>,MemoryGenericRepository<Quiz, int>>();
builder.Services.AddSingleton<IGenericRepository<QuizItem, int>,MemoryGenericRepository<QuizItem, int>>();
builder.Services.AddSingleton<IGenericRepository<QuizItemUserAnswer, string>,MemoryGenericRepository<QuizItemUserAnswer, string>>();

builder.Services.AddSingleton<IQuizUserService, QuizUserService>();
builder.Services.AddSingleton<IQuizAdminService, QuizAdminService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast");


app.MapControllers();
app.Seed();
app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}