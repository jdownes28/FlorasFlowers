using BenchBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BenchBackend.Queries
{
    public interface IGetReviews
    {
        Task<ICollection<ReviewsProjection>> ExecuteAsync(int id);
    }
}