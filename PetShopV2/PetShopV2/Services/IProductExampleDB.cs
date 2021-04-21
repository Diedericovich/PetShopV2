using PetShopV2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShopV2.Services
{
    public interface IProductExampleDB<T> where T : Product
    {
        Task<bool> AddProductAsync(T product);
        Task<bool> DeleteProductAsync(int id);
        List<T> GetAllProducts();
        Task<IEnumerable<T>> GetAllProductsAsync(bool forceRefresh = false);
        Task<T> GetProductAsync(int id);
        Task<bool> UpdateProductAsync(T product);
    }
}