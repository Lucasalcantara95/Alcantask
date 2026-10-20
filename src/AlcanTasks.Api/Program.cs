var builder = WebApplication.CreateBuilder(args);

// Configuration
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data Source=alcantasks.db";

// Dependency Injection
builder.Services.AddApplication();
builder.Services.AddInfrastructure(connectionString);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Endpoints
app.MapPost("/tasks", async (CreateTaskCommand command, IMediator mediator) =>
{
    var id = await mediator.Send(command);
    return Results.Created($"/tasks/{id}", id);
});

app.MapGet("/tasks/daily", async (IMediator mediator) =>
{
    var tasks = await mediator.Send(new GetDailyTasksQuery(DateTime.UtcNow));
    return Results.Ok(tasks);
});

app.MapPatch("/tasks/{id}/status", async (Guid id, bool isCompleted, IMediator mediator) =>
{
    var success = await mediator.Send(new UpdateTaskStatusCommand(id, isCompleted));
    return success ? Results.NoContent() : Results.NotFound();
});

app.Run();

