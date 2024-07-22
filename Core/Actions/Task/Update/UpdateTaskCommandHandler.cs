using System;
using FluentResults;
using System.Threading;
using System.Threading.Tasks;
using Core.DTO.Task;
using Core.DtoConverters;
using DataAccess.Repositories.Interfaces;
using MediatR;

namespace Core.Actions.Task.Update;
using DataAccess.Entities;
public class UpdateTaskCommandHandler: IRequestHandler<UpdateTaskCommand, Result<Unit>>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IDtoConverter<CreateOrModifyTaskDto, Task> _taskDtoConverter;

    public UpdateTaskCommandHandler(
        ITaskRepository taskRepository,
        IDtoConverter<CreateOrModifyTaskDto, Task> taskDtoConverter)
    {
        _taskRepository = taskRepository;
        _taskDtoConverter = taskDtoConverter;
    }
    public async Task<Result<Unit>> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        var convertResult = _taskDtoConverter.Convert(request.dto);
        if(convertResult.IsSuccess)
        {
            Task task = convertResult.Value;
            task.Id = request.id;
            _taskRepository.Update(task);
            _taskRepository.SaveChanges();
            return new Unit();
        }
        return Result.Fail(convertResult.Errors);  
    }
}