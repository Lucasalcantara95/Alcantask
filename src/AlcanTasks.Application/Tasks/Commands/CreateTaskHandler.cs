namespace AlcanTasks.Application.Tasks.Commands;

public class CreateTaskHandler : IRequestHandler<CreateTaskCommand, Guid>
{
    private readonly AppDbContext _context;

    public CreateTaskHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var task = new TaskItem
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Priority = request.Priority,
            IsCompleted = false
        };

        _context.Tasks.Add(task);
        await _context.SaveChangesAsync(cancellationToken);

        return task.Id;
    }
}
