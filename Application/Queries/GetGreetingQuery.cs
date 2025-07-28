using MediatR;

namespace Application.Queries
{
    public record GetGreetingQuery(string Name) : IRequest<string>;
}