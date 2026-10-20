namespace AlcanTasks.Application.Tasks.Queries;

public class GetDailyTasksHandler : IRequestHandler<GetDailyTasksQuery, List<TaskItemDto>>
{
    private readonly AppDbContext _context;

    public GetDailyTasksHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<TaskItemDto>> Handle(GetDailyTasksQuery request, CancellationToken cancellationToken)
    {
        // Using Raw SQL as requested to bypass repositories and return a projection
        // In a real scenario, we might use Dapper here for even more "raw" feel,
        // but EF Core's FromSqlRaw or simple projection is efficient.
        // The user specifically asked for "Queries Brutas retornando em JSON".

        var sql = @"SELECT Id, Name, Priority, IsCompleted
                    FROM Tasks
                    WHERE date(CreatedAt) = date(@p0)
                    ORDER BY Priority ASC";

        return await _context.Database
            .SqlQueryRaw<TaskItemDto>(sql, request.Date)
            .ToListAsync(cancellationToken);
    }
}
