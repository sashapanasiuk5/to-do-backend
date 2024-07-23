using Core.DTO.Task;
using FluentValidation;

namespace Core.DomainRules.Validation;
public class TaskValidator: AbstractValidator<CreateOrModifyTaskDto>
{
    public TaskValidator()
    {
        RuleFor(t => t.Title)
            .NotNull().Length(5, 30);
        RuleFor(t => t.Description)
            .NotNull();
        RuleFor(t => t.StatusId)
            .NotNull();
        RuleFor(t => t.Priority)
            .NotNull().GreaterThan(0);
    }
}