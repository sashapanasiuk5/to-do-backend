using FluentResults;
using MediatR;
using DataAccess.Entities;
namespace Core.Actions.Task.GetAll;

using Task = DataAccess.Entities.Task;
public record GetAllTasksQuery(): IRequest<Result<List<Task>>>;