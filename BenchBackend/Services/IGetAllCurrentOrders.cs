using BenchBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BenchBackend.Services
{
    public interface IGetAllCurrentOrders
    {
        Task<List<OrderProjection>> ExecuteAsync();
    }
}