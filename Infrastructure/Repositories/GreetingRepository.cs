using Domain.Entities;
using Domain.Interfaces;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class GreetingRepository : IGreetingRepository
    {
        public async Task<Greeting> GetGreetingAsync(string name)
        {
            // Simulate fetching data for a query
            await Task.Delay(10);
            return new Greeting { Message = $"Hello from Infrastructure Query, {name}!" };
        }

        public async Task<Greeting> GenerateGreetingAsync(string name)
        {
            // Simulate generating data for a command
            await Task.Delay(10);
            return new Greeting { Message = $"Hello from Infrastructure Command, {name}!" };
        }
    }
}