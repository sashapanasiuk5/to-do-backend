using FluentResults;
using MediatR;

namespace Core.Actions.Task.Delete;
using DataAccess.Entities;
public class DeleteTaskCommandHandler: IRequestHandler<DeleteTaskCommand, Result<Unit>>
{
    public Task<Result<Unit>> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        
    }
}