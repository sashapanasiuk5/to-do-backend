using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentResults;
using MediatR;

namespace Core.Actions.Status.GetAll;

public class GetAllStatusesQueryHandler: IRequestHandler<GetAllStatusesQuery, Result<List<DataAccess.Entities.Status>>>
{
    public Task<Result<List<DataAccess.Entities.Status>>> Handle(GetAllStatusesQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}