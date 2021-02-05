using BenchBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenchBackend.Queries
{
    public interface IGetAllBuyProducts
    {
        Task<List<ProjectionModel>> ExecuteAsync();
    }
}
