using Core.Actions.Task.Create;
using Core.Actions.Task.Delete;
using Core.Actions.Task.GetAll;
using Core.Actions.Task.Update;
using Core.DTO.Task;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Task = DataAccess.Entities.Task;

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

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrModifyTaskDto dto)
    {
        return HandleResult(await _mediator.Send(new CreateTaskCommand(dto)));
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CreateOrModifyTaskDto dto)
    {
        return HandleResult(await _mediator.Send(new UpdateTaskCommand(id, dto)));
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        return HandleResult(await _mediator.Send(new DeleteTaskCommand(id)));
    }
}