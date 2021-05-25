using BenchBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BenchBackend.Services
{
    public interface IGetOrders
    {
        Task<List<OrderProjection>> GetCurrentOrdersAsync();
        Task<List<Order>> GetAllOrdersAsync();
        Task<OrderProjection> GetOrderById(int id);
    }
}