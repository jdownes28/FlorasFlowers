﻿using BenchBackend.Data;
using BenchBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenchBackend.Queries
{
    public class PlaceOrder : IPlaceOrder
    {
        public async Task<Order> ExecuteAsync()
        {
            using FlorasContext context = new FlorasContext();
            Order order = new Order();
            List<OrderContents> listofcontents = new List<OrderContents>();

            //Sample List
            List<int> listOfProductId = new List<int>() { 1, 2 };

            order.OrderPlaced = DateTime.Now;
            order.OrderFulfilled = null;

            foreach (var productId in listOfProductId)
            {
                var product = context.Products.First(id => id.Id == productId);
                OrderContents orderContents = new OrderContents()
                {
                    Product = product,
                    PriceAtTimeOfOrder = product.Price,
                    Name = product.Name
                };
                listofcontents.Add(orderContents);
            }

            order.OrderContents = listofcontents;

            await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();

            return order;
        }
    }
}
