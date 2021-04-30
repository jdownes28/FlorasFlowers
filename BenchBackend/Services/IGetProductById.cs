using BenchBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BenchBackend.Services
{
    public interface IGetProductById
    {
        Task<ProductProjection> ExecuteAsync(int productId);
    }
}