using Core.DTO.Task;
using FluentResults;
using MediatR;

namespace Core.Actions.Task.Create;

public record CreateTaskCommand(CreateOrModifyTaskDto dto): IRequest<Result<DataAccess.Entities.Task>>;