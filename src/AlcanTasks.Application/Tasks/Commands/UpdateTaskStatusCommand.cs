namespace AlcanTasks.Application.Tasks.Commands;

public record UpdateTaskStatusCommand(Guid Id, bool IsCompleted) : IRequest<bool>;

public class UpdateTaskStatusValidator : AbstractValidator<UpdateTaskStatusCommand>
{
    public UpdateTaskStatusValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
