using BenchBackend.Data;
using BenchBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenchBackend.Services
{
    public class PlaceOrder : IPlaceOrder
    {
        private readonly FlorasContext _context;

        public PlaceOrder(FlorasContext context)
        {
            _context = context;
        }

        public async Task<Order> ExecuteAsync(PlaceOrderParameters placeOrderParameters)
        {
            List<OrderContents> orderContents = CreateOrderContents(placeOrderParameters.productsOrderedId);
            double totalOrderPrice = CalculateTotalPrice(orderContents);

            Order order = new Order()
            {
                OrderPlaced = DateTime.Now,
                OrderFulfilled = null,
                OrderContents = orderContents,
                TotalOrderPrice = totalOrderPrice,
                DeliveryAddress = placeOrderParameters.deliveryAddress
            };

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            return order;
        }

        public List<OrderContents> CreateOrderContents(List<int> listOfProductId)
        {
            List<OrderContents> listofcontents = new();

            foreach (var productId in listOfProductId)
            {
                var product = _context.Products.First(id => id.Id == productId);
                OrderContents orderContents = new()
                {
                    PriceAtTimeOfOrder = product.Price,
                    Name = product.Name
                };

                listofcontents.Add(orderContents);
            }

            return listofcontents;
        }

        public double CalculateTotalPrice(ICollection<OrderContents> orderContents)
        {
            double totalOrderPrice = 0;
            foreach (var item in orderContents)
            {
                totalOrderPrice += item.PriceAtTimeOfOrder;
            }

            return totalOrderPrice;
        }
    }
}
