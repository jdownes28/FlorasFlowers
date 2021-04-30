using BenchBackend.Models;
using System.Threading.Tasks;

namespace BenchBackend.Services
{
    public interface IAdminEditProduct
    {
        Task<string> ExecuteAsync(PostEditProductParameters EditedProduct);
    }
}