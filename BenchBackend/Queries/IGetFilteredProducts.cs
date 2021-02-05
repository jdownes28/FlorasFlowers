using BenchBackend.Models;
using System.Collections.Generic;

namespace BenchBackend.Queries
{
    public interface IGetFilteredProducts
    {
        List<ProjectionModel> GetBuyFiltered(int MinPrice, int MaxPrice);
    }
}