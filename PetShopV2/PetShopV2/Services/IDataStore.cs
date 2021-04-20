using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShopV2.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddProductAsync(T product);

        Task<bool> UpdateProductAsync(T product);

        Task<bool> DeleteProductAsync(int id);

        Task<T> GetProductAsync(int id);

        Task<IEnumerable<T>> GetAllProductsAsync(bool forceRefresh = false);
    }
}