using BenchBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenchBackend.Services
{
    public interface IGetSubscriptions
    {
        Task<List<Product>> ExecuteAsync();
    }
}
