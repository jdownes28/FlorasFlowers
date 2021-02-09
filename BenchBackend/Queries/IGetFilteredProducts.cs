using BenchBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BenchBackend.Queries
{
    public interface IGetFilteredProducts
    {
        Task<List<ProductProjection>> GetBuyFiltered(int MinPrice, int MaxPrice);
    }
}