using System.Threading.Tasks;
using Core.Actions.Status.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("statuses")]
public class StatusController: BaseApiController
{
    private IMediator _mediator;
    public StatusController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return HandleResult(await _mediator.Send(new GetAllStatusesQuery()));
    }
}