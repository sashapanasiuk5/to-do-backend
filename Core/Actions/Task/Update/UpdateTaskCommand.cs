using Core.DTO.Task;
using FluentResults;
using MediatR;

namespace Core.Actions.Task.Update;

public record UpdateTaskCommand(int id, CreateOrModifyTaskDto dto): IRequest<Result<Unit>>;