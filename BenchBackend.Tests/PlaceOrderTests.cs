using BenchBackend.Models;
using BenchBackend.Queries;
using System;
using System.Collections.Generic;
using Xunit;

namespace BenchBackend.Tests
{
    public class PlaceOrderTests
    {
        [Fact]
        public void CalculateTotalPriceTest()
        {
            // Arrange
            ICollection<OrderContents> orderContents = new List<OrderContents>();
            OrderContents contents = new OrderContents()
            {
                Id = 56,
                Name = "Roses Boquet",
                PriceAtTimeOfOrder = 15.75
            };

            orderContents.Add(contents);
            orderContents.Add(contents);

            // Act
            PlaceOrder placeOrder = new PlaceOrder();
            double result = placeOrder.CalculateTotalPrice(orderContents);

            // Assert
            Assert.Equal(31.50, result);
        }
    }
}
