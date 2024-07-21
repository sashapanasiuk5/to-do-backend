using Core.DTO.Task;
using FluentResults;
using MediatR;

namespace Core.Actions.Task.Update;

public record UpdateTaskCommand(CreateOrModifyTaskDto dto): IRequest<Result<Unit>>;