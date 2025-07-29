using MediatR;
using Application.Queries;
using Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers
{
    public class GetGreetingQueryHandler : IRequestHandler<GetGreetingQuery, string>
    {
        private readonly IGreetingRepository _greetingRepository;

        public GetGreetingQueryHandler(IGreetingRepository greetingRepository)
        {
            _greetingRepository = greetingRepository;
        }

        public async Task<string> Handle(GetGreetingQuery request, CancellationToken cancellationToken)
        {
            var greeting = await _greetingRepository.GetGreetingAsync(request.Name);
            return greeting.Message;
        }
    }
}