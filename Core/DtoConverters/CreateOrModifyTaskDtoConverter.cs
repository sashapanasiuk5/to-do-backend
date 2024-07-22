using Core.DTO.Task;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using FluentResults;
using Task = DataAccess.Entities.Task;

namespace Core.DtoConverters;

public class CreateOrModifyTaskDtoConverter: IDtoConverter<CreateOrModifyTaskDto, Task>
{
    private readonly IStatusRepository _statusRepository;
    public CreateOrModifyTaskDtoConverter(IStatusRepository statusRepository)
    {
        _statusRepository = statusRepository;
    }
    
    public Result<Task> Convert(CreateOrModifyTaskDto dto)
    {
        Task task = new Task()
        {
            Title = dto.Title,
            Description = dto.Description,
            Priority = dto.Priority
        };
        Status? status = _statusRepository.GetById(dto.StatusId);
        if (status != null)
        {
            task.Status = status;
            return Result.Ok(task);
        }
        return Result.Fail($"Status with id {dto.StatusId} is not found");
    }

    public Result<CreateOrModifyTaskDto> ConvertBack(Task entity)
    {
        var dto = new CreateOrModifyTaskDto()
        {
            Title = entity.Title,
            Description = entity.Description,
            Priority = entity.Priority,
            StatusId = entity.Status.Id
        };
        return Result.Ok(dto);
    }
}