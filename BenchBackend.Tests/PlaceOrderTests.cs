using BenchBackend.Models;
using BenchBackend.Services;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace BenchBackend.Tests
{
    public class PlaceOrderTests
    {
        private readonly IPlaceOrder _placeOrder;

        public PlaceOrderTests(IPlaceOrder placeOrder)
        {
            _placeOrder = placeOrder;
        }

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
            double result = _placeOrder.CalculateTotalPrice(orderContents);

            // Assert
            Assert.Equal(31.50, result);
        }
    }
}
