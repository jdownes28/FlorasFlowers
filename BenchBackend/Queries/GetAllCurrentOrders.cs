using BenchBackend.Data;
using BenchBackend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenchBackend.Queries
{
    public class GetAllCurrentOrders : IGetAllCurrentOrders
    {
        public async Task<List<OrderProjection>> ExecuteAsync()
        {
            using FlorasContext context = new FlorasContext();

            var CurrentOrders = await context.Orders
                .Include(oc => oc.OrderContents)
                .Where(order => order.OrderFulfilled == null)
                .Select(select => new OrderProjection
                {
                    OrderPlaced = select.OrderPlaced,
                    Address = select.DeliveryAddress,
                    Name = $"{select.Customer.FirstName} {select.Customer.LastName}",
                    ProductsOrdered = select.OrderContents,
                    TotalPrice = select.TotalOrderPrice,
                }).ToListAsync();

            return CurrentOrders;
        }

    }
}
