using Application.Commands;
using Application.Queries;
using Domain.Aggregates.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController: ControllerBase
{
    private readonly IMediator _mediator;

    public OrdersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<object>> Create()
    {
        var result = await _mediator.Send(new CreateNewOrderCommand());
        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<ICollection<object>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllOrdersQuery());
        return Ok(result);
    }
}