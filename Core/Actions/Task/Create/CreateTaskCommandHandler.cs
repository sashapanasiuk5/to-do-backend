using System;
using System.Threading;
using System.Threading.Tasks;
using Core.Mapping;
using DataAccess.Repositories.Interfaces;
using FluentResults;
using MediatR;

namespace Core.Actions.Task.Create;
using DataAccess.Entities;
public class CreateTaskCommandHandler: IRequestHandler<CreateTaskCommand, Result<Unit>>
{
    private readonly IStatusRepository _statusRepository;
    private readonly ITaskRepository _taskRepository;
    public CreateTaskCommandHandler(IStatusRepository statusRepository, ITaskRepository taskRepository)
    {
        _statusRepository = statusRepository;
        _taskRepository = taskRepository;
    }
    public async Task<Result<Unit>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        Task task = request.dto.ToTask();
        Status? status = _statusRepository.GetById(request.dto.StatusId);
        if (status != null)
        {
            task.Status = status;
            _taskRepository.Add(task);
            _taskRepository.SaveChanges();
            return new Unit();
        }
        return Result.Fail("Status is not found"); 
    }
}