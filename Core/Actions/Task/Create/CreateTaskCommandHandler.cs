using System;
using System.Threading;
using System.Threading.Tasks;
using FluentResults;
using MediatR;

namespace Core.Actions.Task.Create;

public class CreateTaskCommandHandler: IRequestHandler<CreateTaskCommand, Result<Unit>>
{
    public Task<Result<Unit>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}