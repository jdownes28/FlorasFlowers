using BenchBackend.Data;
using BenchBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenchBackend.Queries
{
    public class PlaceOrder : IPlaceOrder
    {
        public async Task<Order> ExecuteAsync(PlaceOrderParameters placeOrderParameters)
        {
            using FlorasContext context = new FlorasContext();

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

            await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();

            return order;
        }

        public List<OrderContents> CreateOrderContents(List<int> listOfProductId)
        {
            using FlorasContext context = new FlorasContext();

            List<OrderContents> listofcontents = new List<OrderContents>();

            foreach (var productId in listOfProductId)
            {
                var product = context.Products.First(id => id.Id == productId);
                OrderContents orderContents = new OrderContents()
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
