using System;
using FluentResults;
using System.Threading;
using System.Threading.Tasks;
using Core.Mapping;
using DataAccess.Repositories.Interfaces;
using MediatR;

namespace Core.Actions.Task.Update;
using DataAccess.Entities;
public class UpdateTaskCommandHandler: IRequestHandler<UpdateTaskCommand, Result<Unit>>
{
    private readonly IStatusRepository _statusRepository;
    private readonly ITaskRepository _taskRepository;

    public UpdateTaskCommandHandler(IStatusRepository statusRepository, ITaskRepository taskRepository)
    {
        _statusRepository = statusRepository;
        _taskRepository = taskRepository;
    }
    public async Task<Result<Unit>> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        Task task = request.dto.ToTask();
        task.Id = request.id;
        Status? status = _statusRepository.GetById(request.dto.StatusId);
        if (status != null)
        {
            task.Status = status;
            _taskRepository.Update(task);
            _taskRepository.SaveChanges();
            return new Unit();
        }
        return Result.Fail("Status is not found"); 
    }
}