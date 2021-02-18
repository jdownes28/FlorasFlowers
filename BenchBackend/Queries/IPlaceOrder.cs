using BenchBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BenchBackend.Queries
{
    public interface IPlaceOrder
    {
        Task<Order> ExecuteAsync(PlaceOrderParameters placeOrderParameters);
        double CalculateTotalPrice(ICollection<OrderContents> orderContents);
        List<OrderContents> CreateOrderContents(List<int> listOfProductId);
    }
}