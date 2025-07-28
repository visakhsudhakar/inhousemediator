using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Commands;
using Application.Queries;

[ApiController]
[Route("[controller]")]
public class GreetingController : ControllerBase
{
    private readonly IMediator _mediator;

    public GreetingController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("command")]
    public async Task<IActionResult> GetGreetingFromCommand([FromQuery] string name)
    {
        var greeting = await _mediator.Send(new GreetCommand(name));
        return Ok(greeting);
    }

    [HttpGet("query")]
    public async Task<IActionResult> GetGreetingFromQuery([FromQuery] string name)
    {
        var greeting = await _mediator.Send(new GetGreetingQuery(name));
        return Ok(greeting);
    }
}