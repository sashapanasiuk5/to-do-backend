using FluentResults;
using MediatR;

namespace Core.Actions.Task.Delete;

public record DeleteTaskCommand(int taskId): IRequest<Result<Unit>>;