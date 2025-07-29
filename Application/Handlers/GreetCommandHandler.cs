using MediatR;
using Application.Commands;
using Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers
{
    public class GreetCommandHandler : IRequestHandler<GreetCommand, string>
    {
        private readonly IGreetingRepository _greetingRepository;

        public GreetCommandHandler(IGreetingRepository greetingRepository)
        {
            _greetingRepository = greetingRepository;
        }

        public async Task<string> Handle(GreetCommand request, CancellationToken cancellationToken)
        {
            var greeting = await _greetingRepository.GenerateGreetingAsync(request.Name);
            return greeting.Message;
        }
    }
}