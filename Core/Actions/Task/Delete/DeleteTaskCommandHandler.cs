using DataAccess.Repositories.Interfaces;
using FluentResults;
using MediatR;

namespace Core.Actions.Task.Delete;
using DataAccess.Entities;
public class DeleteTaskCommandHandler: IRequestHandler<DeleteTaskCommand, Result<Unit>>
{
    private readonly ITaskRepository _taskRepository;

    public DeleteTaskCommandHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }
    public async Task<Result<Unit>> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        _taskRepository.Delete(request.taskId);
        return Result.Ok(new Unit());
    }
}