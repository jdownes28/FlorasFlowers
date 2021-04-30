using BenchBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BenchBackend.Services
{
    public interface IGetReviews
    {
        Task<ICollection<ReviewsProjection>> ExecuteAsync(int id);
    }
}