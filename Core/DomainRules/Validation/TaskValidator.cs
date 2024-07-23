using Core.DTO.Task;
using FluentValidation;

namespace Core.DomainRules.Validation;
public class TaskValidator: AbstractValidator<CreateOrModifyTaskDto>
{
    public TaskValidator()
    {
        RuleFor(t => t.Title)
            .NotNull().Length(5, 30).WithMessage("The length of title must be more than 5 and less than 30 characters");
        RuleFor(t => t.Description)
            .NotNull().WithMessage("Description must be not empty");
        RuleFor(t => t.StatusId)
            .NotNull().WithMessage("StatusId must be not empty");
        RuleFor(t => t.Priority)
            .NotNull().GreaterThan(0).WithMessage("Priority must be greater than 0");
    }
}