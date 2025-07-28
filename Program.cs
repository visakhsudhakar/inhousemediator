using Application.Commands;
using Application.Queries;
using MediatR;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build(); // Add this line to define 'app'

// Add MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly(), Assembly.Load("Application")));

// Ensure the correct interface name is used
app.MapGet("/greet-command", async (IMediator mediator, string name) =>
{
    var greeting = await mediator.Send(new GreetCommand(name));
    return greeting;
});

app.MapGet("/greet-query", async (IMediator mediator, string name) =>
{
    var greeting = await mediator.Send(new GetGreetingQuery(name));
    return greeting;
});

app.Run(); // Remove 'url' parameter if not defined