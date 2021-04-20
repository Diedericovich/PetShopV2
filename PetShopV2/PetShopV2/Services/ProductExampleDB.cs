using PetShop.Models;
using PetShopV2.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopV2.Services
{
    public class ProductExampleDB : IDataStore<Product>
    {

        private List<Product> items;

        public ProductExampleDB()
        {
            if (items == null)
            {
                AddDummyData();
            }
        }

        public Task<bool> AddProductAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProductAsync(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProducts()
        {
            return items;
        }

        public Task<Product> GetProductAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProductsAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateProductAsync(Product product)
        {
            throw new NotImplementedException();
        }

        private void AddDummyData()
        {
            items = new List<Product>
                {
                        new Food
                        {
                            ID = 1,
                            Name = "Delicious Chicken Terrine",
                            Description = "Contains alot of chicken and terrine",
                            Image = "Food.jpg",
                            Price = 0.50,
                            InStock = true,
                            Animal = AnimalType.Cat,
                            ItemBrand = "Whiskas",
                            FoodWeight = 5,
                            IsGrainFree = true,


                        },
                        new Toys
                        {
                            ID = 2,
                            Name = "Dog Ball",
                            Description = "a colourful rubber ball which makes lot of sound and noise",
                            Image = "Toys.jpg",
                            Price = 0,
                            InStock = true,
                            Animal = AnimalType.Dog,
                            ItemBrand = "Roughware",
                            ContainsLatex = true,
                            IsTough = true,
                            IsInteractive = true,
                            MakesSound = true,
                        }
                };

        }

    }
}
