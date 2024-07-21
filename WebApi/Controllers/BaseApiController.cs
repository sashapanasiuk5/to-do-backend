using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class BaseApiController: ControllerBase
{
    protected ActionResult HandleResult<T>(Result<T> result)
    {
        if (result.IsSuccess)
        {
            if (result.Value is Unit)
            {
                return Ok(null);
            }

            return Ok(result.Value);
        }

        return BadRequest(result.Reasons);
    }
}