using Core.DomainErrors;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApi.Responses;

namespace WebApi.Middleware;

public class ErrorResponseFilter: IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        switch (context.Result)
        {
            case BadRequestObjectResult badRequestResult:
                var validationError = badRequestResult.Value as ValidationError;
                badRequestResult.Value = new ErrorResponse()
                {
                    Error = validationError.Message,
                    Details = validationError.Reasons.Select(e => e.Message).ToList()
                };
                break;
            case NotFoundObjectResult notFoundObjectResult:
                var notFoundError = notFoundObjectResult.Value as NotFoundError;
                notFoundObjectResult.Value = new ErrorResponse()
                {
                    Error = notFoundError.Message
                };
                break;
        }
    }
}