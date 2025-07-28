using MediatR;
using Application.Commands;

namespace Application.Handlers
{
    public class GreetCommandHandler : IRequestHandler<GreetCommand, string>
    {
        public async Task<string> Handle(GreetCommand request, CancellationToken cancellationToken)
        {
            return $"Hello from CQRS, {request.Name}!";
        }
    }
}