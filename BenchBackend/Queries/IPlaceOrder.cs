using BenchBackend.Models;
using System.Threading.Tasks;

namespace BenchBackend.Queries
{
    public interface IPlaceOrder
    {
        Task<Order> ExecuteAsync();
    }
}