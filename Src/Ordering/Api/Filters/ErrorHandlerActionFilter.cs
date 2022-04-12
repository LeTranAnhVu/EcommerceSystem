using System.Net;
using Api.Common;
using Application.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Filters;

public class ErrorHandlerActionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (!context.ExceptionHandled && context.Exception is FluentValidation.ValidationException validationException)
        {
            context.Result = ErrorObjectResult.MakeBadRequest(validationException.Message);
        }
        else
        {
            context.Result = ErrorObjectResult.MakeInternalError(context.Exception.Message);
        }
    }
}