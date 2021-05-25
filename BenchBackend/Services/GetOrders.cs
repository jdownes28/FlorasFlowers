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
            // Use Projection to avoid sending password
            var CurrentOrders = await _context.Orders
                .Include(oc => oc.OrderContents)
                .ThenInclude(pr => pr.Product)
                .Where(order => order.OrderFulfilled == null)
                .Select(select => new OrderProjection
                {
                    Id = select.Id,
                    OrderPlaced = select.OrderPlaced.ToString("dd/MM/yyyy HH:mm:ss"),
                    Address = select.DeliveryAddress,
                    Name = $"{select.Customer.FirstName} {select.Customer.LastName}",
                    Email = select.Customer.Email,
                    TotalOrderPrice = select.TotalOrderPrice,
                    ProductsOrdered = select.OrderContents,
                }).ToListAsync();

            return CurrentOrders;
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            var allOrders = await _context.Orders
                .Include(oc => oc.OrderContents).ThenInclude(p => p.Product).ThenInclude(pt => pt.ProductType)
                .Include(cus => cus.Customer)
                .ToListAsync();

            return allOrders;
        }

        public async Task<OrderProjection> GetOrderById(int id)
        {
            OrderProjection order = await _context.Orders
                .Include(oc => oc.OrderContents)
                .ThenInclude(pr => pr.Product)
                .Include(cus => cus.Customer)
                .Where(o => o.Id == id)
                .Select(select => new OrderProjection
                {
                    Id = select.Id,
                    OrderPlaced = select.OrderPlaced.ToShortDateString(),
                    Name = $"{select.Customer.FirstName} {select.Customer.LastName}",
                    Email = select.Customer.Email,
                    Address = select.DeliveryAddress,
                    TotalOrderPrice = select.TotalOrderPrice,
                    ProductsOrdered = select.OrderContents
                })
                .FirstOrDefaultAsync();

            OrderProjection result = order ?? null;

            return result;
        }

    }
}
