using PetShopV2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShopV2.Services
{
    public interface IProductExampleDB<T> where T : Model
    {
        Task AddProductAsync(T model);
        Task DeleteProductAsync(int id);
        Task<IEnumerable<T>> GetAllProductsAsync(bool forceRefresh = false);
        Task<T> GetProductAsync(int id);
        Task UpdateProductAsync(T product);
    }
}