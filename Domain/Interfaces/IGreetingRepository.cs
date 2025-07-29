using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IGreetingRepository
    {
        Task<Greeting> GetGreetingAsync(string name);
        Task<Greeting> GenerateGreetingAsync(string name);
    }
}