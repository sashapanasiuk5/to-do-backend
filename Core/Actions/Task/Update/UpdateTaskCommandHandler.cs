using FluentResults;
using MediatR;

namespace Core.Actions.Task.Update;

public class UpdateTaskCommandHandler: IRequestHandler<UpdateTaskCommand, Result<Unit>>
{
    public Task<Result<Unit>> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}