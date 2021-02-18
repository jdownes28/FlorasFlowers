using BenchBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BenchBackend.Queries
{
    public interface IPlaceOrder
    {
        Task<Order> ExecuteAsync();
        double CalculateTotalPrice(ICollection<OrderContents> orderContents);
    }
}