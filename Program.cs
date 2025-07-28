using MediatR;
using System.Reflection;
using Application.Commands;
using Application.Queries;

var builder = WebApplication.CreateBuilder(args);

// Add MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly(), Assembly.Load("Application")));

var port = Environment.GetEnvironmentVariable("PORT") ?? "3000";
var url = $"http://0.0.0.0:{port}";

var app = builder.Build();

app.MapGet("/greet-command", async (IMediatR mediator, string name) =>
{
    var greeting = await mediator.Send(new GreetCommand(name));
    return greeting;
});

app.MapGet("/greet-query", async (IMediatR mediator, string name) =>
{
    var greeting = await mediator.Send(new GetGreetingQuery(name));
    return greeting;
});

app.Run(url);