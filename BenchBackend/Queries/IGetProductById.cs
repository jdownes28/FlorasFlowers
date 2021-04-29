using BenchBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BenchBackend.Queries
{
    public interface IGetProductById
    {
        Task<List<ProductProjection>> ExecuteAsync(int productId);
    }
}