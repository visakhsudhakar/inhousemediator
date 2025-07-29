using Domain.Entities;
using Domain.Interfaces;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class GreetingRepository : IGreetingRepository
    {
        public async Task<Greeting> GetGreetingAsync(string name)
        {
            // Simulate fetching data
            await Task.Delay(10);
            return new Greeting { Message = $"Hello from Infrastructure, {name}!" };
        }
    }
}