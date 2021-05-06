using BenchBackend.Data;
using BenchBackend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenchBackend.Services
{
    public class GetOrders : IGetOrders
    {

        private readonly FlorasContext _context;

        public GetOrders(FlorasContext context)
        {
            _context = context;
        }

        public async Task<List<OrderProjection>> GetCurrentOrdersAsync()
        {
            var CurrentOrders = await _context.Orders
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

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            using FlorasContext context = new();
            var allOrders = await context.Orders
                .Include(oc => oc.OrderContents).ThenInclude(p => p.Product).ThenInclude(pt => pt.ProductType)
                .Include(cus => cus.Customer)
                .ToListAsync();

            return allOrders;
        }

    }
}
