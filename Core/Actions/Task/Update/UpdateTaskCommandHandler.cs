using FluentResults;
using DataAccess.Repositories.Interfaces;
using MediatR;

namespace Core.Actions.Task.Update;
using DataAccess.Entities;
public class UpdateTaskCommandHandler: IRequestHandler<UpdateTaskCommand, Result<Unit>>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IStatusRepository _statusRepository;

    public UpdateTaskCommandHandler
    (
        ITaskRepository taskRepository,
        IStatusRepository statusRepository
    )
    {
        _statusRepository = statusRepository;
        _taskRepository = taskRepository;
    }
    public async Task<Result<Unit>> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        Status? status = _statusRepository.GetById(request.dto.StatusId);
        if(status == null)
            return Result.Fail("Status is not found");

        Task? taskForUpdate = _taskRepository.GetById(request.id);
        if(taskForUpdate == null)
            return Result.Fail("Task is not found");

        taskForUpdate.Title = request.dto.Title;
        taskForUpdate.Description = request.dto.Description;
        taskForUpdate.Priority = request.dto.Priority;
        taskForUpdate.Status = status;
        _taskRepository.Update(taskForUpdate);
        _taskRepository.SaveChanges();
        return new Unit();
    }
}