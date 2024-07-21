using FluentResults;
using MediatR;

namespace Core.Actions.Task.Delete;

public class DeleteTaskCommandHandler: IRequestHandler<DeleteTaskCommand, Result<Unit>>
{
    public Task<Result<Unit>> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}