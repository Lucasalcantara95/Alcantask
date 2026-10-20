namespace AlcanTasks.Application.Tasks.Commands;

public record CreateTaskCommand(string Name, int Priority) : IRequest<Guid>;

public class CreateTaskValidator : AbstractValidator<CreateTaskCommand>
{
    public CreateTaskValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Priority).InclusiveBetween(1, 3);
    }
}
