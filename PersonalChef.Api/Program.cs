using Microsoft.EntityFrameworkCore;
using PersonalChef.Api.Mappers;
using PersonalChef.Api.Models;
using PersonalChef.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

builder.Services.AddControllers();
builder.Services.AddDbContextFactory<RecipeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PersonalChefDb"), sqlOptions =>
    {
        // Workround for https://github.com/dotnet/aspire/issues/1023
        sqlOptions.ExecutionStrategy(c => new RetryingSqlServerRetryingExecutionStrategy(c));
    }));
builder.EnrichSqlServerDbContext<RecipeContext>(settings =>
    // Disable Aspire default retries as we're using a custom execution strategy
    settings.DisableRetry = true);

builder.Services.AddScoped<IRecipeService, RecipeService>();
builder.Services.AddScoped<IMapper<PersonalChef.DataModel.Model.Recipe, Recipe>, RecipeMapper>();
builder.Services.AddScoped<IMapper<PersonalChef.DataModel.Model.RecipeStep, RecipeStep>, RecipeStepMapper>();
builder.Services.AddScoped<IMapper<PersonalChef.DataModel.Model.RecipeIngredient, RecipeIngredient>, RecipeIngredientMapper>();


var app = builder.Build();

app.MapDefaultEndpoints();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller}/{action=Index}/{id?}");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(static builder => 
    builder.AllowAnyMethod()
        .AllowAnyHeader()
        .AllowAnyOrigin());

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.MapGet("/", async (RecipeContext context) =>
{
    var entries = await context.MeasurementUnits.ToListAsync();

    return new
    {
        totalEntries = entries.Count,
        units = entries
    };
});

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
