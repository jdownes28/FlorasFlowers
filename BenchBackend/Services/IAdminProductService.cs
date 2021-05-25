using BenchBackend.Models;
using System.Threading.Tasks;

namespace BenchBackend.Services
{
    public interface IAdminProductService
    {
        Task AddProductAsync(Product product);
        Task<string> EditProductAsync(PostEditProductParameters EditedProduct);
    }
}