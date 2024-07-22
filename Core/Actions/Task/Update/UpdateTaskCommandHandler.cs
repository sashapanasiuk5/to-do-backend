using System;
using FluentResults;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Core.Actions.Task.Update;

public class UpdateTaskCommandHandler: IRequestHandler<UpdateTaskCommand, Result<Unit>>
{
    public Task<Result<Unit>> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}