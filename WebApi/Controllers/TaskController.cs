using Core.Actions.Task.GetAll;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("tasks")]
public class TaskController : BaseApiController
{
    private IMediator _mediator;
    public TaskController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllTasksAsync()
    {
        return HandleResult(await _mediator.Send(new GetAllTasksQuery()));
    }
}