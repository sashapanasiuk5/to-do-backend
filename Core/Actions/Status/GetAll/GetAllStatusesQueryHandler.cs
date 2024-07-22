using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Repositories.Interfaces;
using FluentResults;
using MediatR;

namespace Core.Actions.Status.GetAll;

public class GetAllStatusesQueryHandler: IRequestHandler<GetAllStatusesQuery, Result<List<DataAccess.Entities.Status>>>
{
    private readonly IStatusRepository _statusRepository;

    public GetAllStatusesQueryHandler(IStatusRepository statusRepository)
    {
        _statusRepository = statusRepository;
    }
    public async Task<Result<List<DataAccess.Entities.Status>>> Handle(GetAllStatusesQuery request, CancellationToken cancellationToken)
    {
        return Result.Ok(_statusRepository.GetAll());
    }
}