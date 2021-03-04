using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace BenchBackend.Tests
{
    public class ProductControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private HttpClient Client { get; }

        public ProductControllerTests(WebApplicationFactory<Startup> fixture)
        {
            // Arrange Client
            Client = fixture.CreateClient();
        }

        [Fact]
        public async Task GetProductsAsync()
        {
            // Act
            var response = await Client.GetAsync("/products");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }

        [Fact]
        public async Task GetFilteredProductsAsync()
        {
            // Act
            var response = await Client.GetAsync("/products/filter");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }

        /*
         * Expected failure due to auth restrictions
        [Fact]
        public async Task GetSubscriptionsAsync()
        {
            // Act
            var response = await Client.GetAsync("/subscriptions");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }
        */
    }
}
