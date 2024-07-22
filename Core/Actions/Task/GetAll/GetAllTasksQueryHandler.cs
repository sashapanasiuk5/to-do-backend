using System;
using System.Collections.Generic;
using DataAccess.Entities;
using FluentResults;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Repositories.Interfaces;
using MediatR;

namespace Core.Actions.Task.GetAll;

public class GetAllTasksQueryHandler: IRequestHandler<GetAllTasksQuery, Result<List<DataAccess.Entities.Task>>>
{
    private readonly ITaskRepository _taskRepository;
    public GetAllTasksQueryHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }
    public async Task<Result<List<DataAccess.Entities.Task>>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
    {
        return Result.Ok(_taskRepository.GetAll());
    }
}