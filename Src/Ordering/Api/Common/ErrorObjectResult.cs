using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Api.Common;

public class ErrorObjectResult
{
    public string Message { get; set; }
    public HttpStatusCode StatusCode { get; set; }

    public ErrorObjectResult(HttpStatusCode statusCode, string message)
    {
        StatusCode = statusCode;
        Message = message;
    }

    public static ObjectResult MakeInternalError(string? messsage)
    {
        var result = new ErrorObjectResult(HttpStatusCode.InternalServerError, messsage ?? "Internal server error");
        return new ObjectResult(result) {StatusCode = (int) HttpStatusCode.InternalServerError};
    }

    public static ObjectResult MakeBadRequest(string messsage)
    {
        var result = new ErrorObjectResult(HttpStatusCode.BadRequest, messsage);
        return new ObjectResult(result) {StatusCode = (int) HttpStatusCode.BadRequest};
    }
}