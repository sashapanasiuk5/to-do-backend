using Core.DomainErrors;
using Core.DTO.Task;
using FluentResults;
using DataAccess.Repositories.Interfaces;
using FluentValidation;
using MediatR;

namespace Core.Actions.Task.Update;
using DataAccess.Entities;
public class UpdateTaskCommandHandler: IRequestHandler<UpdateTaskCommand, Result<Unit>>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IStatusRepository _statusRepository;
    private readonly IValidator<CreateOrModifyTaskDto> _taskDtoValidator;
    public UpdateTaskCommandHandler
    (
        ITaskRepository taskRepository,
        IStatusRepository statusRepository,
        IValidator<CreateOrModifyTaskDto> taskDtoValidator)
    {
        _statusRepository = statusRepository;
        _taskRepository = taskRepository;
        _taskDtoValidator = taskDtoValidator;
    }
    public async Task<Result<Unit>> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        var result = _taskDtoValidator.Validate(request.dto);
        if (!result.IsValid)
            return Result.Fail(new ValidationError(result.Errors));
        
        Status? status = _statusRepository.GetById(request.dto.StatusId);
        if(status == null)
            return Result.Fail(new NotFoundError(typeof(Status),request.dto.StatusId));

        Task? taskForUpdate = _taskRepository.GetById(request.id);
        if(taskForUpdate == null)
            return Result.Fail(new NotFoundError(typeof(Task), request.id));

        taskForUpdate.Title = request.dto.Title;
        taskForUpdate.Description = request.dto.Description;
        taskForUpdate.Priority = request.dto.Priority;
        taskForUpdate.Status = status;
        _taskRepository.Update(taskForUpdate);
        _taskRepository.SaveChanges();
        return new Unit();
    }
}