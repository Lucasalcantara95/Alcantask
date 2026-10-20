namespace AlcanTasks.Application.Tasks.Commands;

public class UpdateTaskStatusHandler : IRequestHandler<UpdateTaskStatusCommand, bool>
{
    private readonly AppDbContext _context;

    public UpdateTaskStatusHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateTaskStatusCommand request, CancellationToken cancellationToken)
    {
        var task = await _context.Tasks.FindAsync(new object[] { request.Id }, cancellationToken);
        if (task == null) return false;

        task.IsCompleted = request.IsCompleted;
        task.CompletedAt = request.IsCompleted ? DateTime.UtcNow : null;

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
