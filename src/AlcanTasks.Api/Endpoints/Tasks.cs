namespace AlcanTasks.Api.Endpoints;

internal static class Tasks
{
    internal static void MapTasksEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/tasks");
        group.WithTags("Tasks");
        group.MapPost("/", async (CreateTaskCommand command, IMediator mediator) =>
        {
            var id = await mediator.Send(command);
            return Results.Created($"/tasks/{id}", id);
        });
        group.WithSummary("Cria uma nova tarefa");



        group.MapGet("/tasks/daily", async (IMediator mediator) =>
        {
            var tasks = await mediator.Send(new GetDailyTasksQuery(DateTime.UtcNow));
            return Results.Ok(tasks);
        });
        group.WithSummary("Obtém as tarefas diárias");


        group.MapPatch("/tasks/{id}/status", async (Guid id, bool isCompleted, IMediator mediator) =>
        {
            var success = await mediator.Send(new UpdateTaskStatusCommand(id, isCompleted));
            return success ? Results.NoContent() : Results.NotFound();
        });
        group.WithSummary("Atualiza o status de uma tarefa");
    }
}