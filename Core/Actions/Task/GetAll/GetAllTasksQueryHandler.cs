using DataAccess.Entities;
using FluentResults;
using MediatR;

namespace Core.Actions.Task.GetAll;

public class GetAllTasksQueryHandler: IRequestHandler<GetAllTasksQuery, Result<List<DataAccess.Entities.Task>>>
{
    public async Task<Result<List<DataAccess.Entities.Task>>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}