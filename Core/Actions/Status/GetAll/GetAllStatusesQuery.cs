using FluentResults;
using MediatR;

namespace Core.Actions.Status.GetAll;

public record GetAllStatusesQuery() : IRequest<Result<List<DataAccess.Entities.Status>>>;