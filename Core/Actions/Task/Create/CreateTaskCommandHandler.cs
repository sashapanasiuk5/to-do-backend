using Core.DTO.Task;
using Core.DtoConverters;
using DataAccess.Repositories.Interfaces;
using FluentResults;
using MediatR;

namespace Core.Actions.Task.Create;
using DataAccess.Entities;
public class CreateTaskCommandHandler: IRequestHandler<CreateTaskCommand, Result<Unit>>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IDtoConverter<CreateOrModifyTaskDto, Task> _taskDtoConverter;
    public CreateTaskCommandHandler(
        ITaskRepository taskRepository,
        IDtoConverter<CreateOrModifyTaskDto, Task> taskDtoConverter)
    {
        _taskRepository = taskRepository;
        _taskDtoConverter = taskDtoConverter;
    }
    public async Task<Result<Unit>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var convertResult = _taskDtoConverter.Convert(request.dto);
        if(convertResult.IsSuccess)
        {
            _taskRepository.Add(convertResult.Value);
            _taskRepository.SaveChanges();
            return new Unit();
        }
        return Result.Fail(convertResult.Errors); 
    }
}