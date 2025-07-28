using MediatR;

namespace Application.Commands
{
    public record GreetCommand(string Name) : IRequest<string>;
}