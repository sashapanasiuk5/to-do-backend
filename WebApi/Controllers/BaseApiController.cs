﻿using Core.DomainErrors;
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
                return Ok(null);
            
            return Ok(result.Value);
        }
        
        IError error = result.Errors[0];
        return HandleError(error);
    }

    private ActionResult HandleError(IError error)
    {
        switch (error)
        {
            case NotFoundError:
                return NotFound(error.Message);
            default:
                throw new Exception("Not expected error");
        }
    }
    
}