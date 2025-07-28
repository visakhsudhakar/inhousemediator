using MediatR;
using Application.Queries;

namespace Application.Handlers
{
    public class GetGreetingQueryHandler : IRequestHandler<GetGreetingQuery, string>
    {
        public async Task<string> Handle(GetGreetingQuery request, CancellationToken cancellationToken)
        {
            return $"Hello from CQRS Query, {request.Name}!";
        }
    }
}