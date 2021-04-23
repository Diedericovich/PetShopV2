using Microsoft.EntityFrameworkCore;
using PetShopV2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopV2.Services
{
    public class ProductExampleDB<T> : IProductExampleDB<T> where T : Model
    {
        private List<T> products;

       
        public async Task AddProductAsync(T model)
        {
            using (var dbContext = new PetShopContext())
            {
                dbContext.Add(model);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteProductAsync(int id)
        {
            using (var dbContext = new PetShopContext())
            {
                var oldItem = products.FirstOrDefault(x => x.ID == id);
                dbContext.Remove(oldItem);
                await dbContext.SaveChangesAsync();
            }
        }


        public async Task<T> GetProductAsync(int id)
        {
            using (var dbContext = new PetShopContext())
            {
                return await dbContext.FindAsync<T>(id);
            }
        }

        public async Task<IEnumerable<T>> GetAllProductsAsync(bool forceRefresh = false)
        {
            using (var dbContext = new PetShopContext())
            {
                var table = dbContext.Set<T>();

                return await table.ToListAsync();
            }
        }

        public async Task UpdateProductAsync(T product)
        {
            using (var dbContext = new PetShopContext())
            {
                dbContext.Update<T>(product);
                await dbContext.SaveChangesAsync();
            }
        }

        
    }
}