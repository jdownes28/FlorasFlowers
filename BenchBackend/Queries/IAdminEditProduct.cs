using BenchBackend.Models;
using System.Threading.Tasks;

namespace BenchBackend.Queries
{
    public interface IAdminEditProduct
    {
        Task<string> ExecuteAsync(PostEditProductParameters EditedProduct);
    }
}