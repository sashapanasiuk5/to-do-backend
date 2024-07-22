using Core.DTO.Task;
using Task = DataAccess.Entities.Task;

namespace Core.Mapping;

public static class TaskMapper
{
    public static Task ToTask(this CreateOrModifyTaskDto dto)
    {
        return new Task()
        {
            Title = dto.Title,
            Description = dto.Description,
            Priority = dto.Priority
        };
    }
}