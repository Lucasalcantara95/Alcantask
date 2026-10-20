namespace AlcanTasks.Application.Tasks.Queries;

public record GetDailyTasksQuery(DateTime Date) : IRequest<List<TaskItemDto>>;

public record TaskItemDto(Guid Id, string Name, int Priority, bool IsCompleted);
