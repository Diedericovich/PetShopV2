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
        private List<Product> products;

        public ProductExampleDB()
        {
            if (products == null)
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
            return products;
        }

        public async Task<Product> GetProductAsync(int id)
        {
            return await Task.FromResult(products.FirstOrDefault(s => s.ID == id));
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(products);
        }

        public Task<bool> UpdateProductAsync(Product product)
        {
            throw new NotImplementedException();
        }

        private void AddDummyData()
        {
            products = new List<Product>
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
                         new Food
                        {
                            ID = 2,
                            Name = "Veal Dry Food",
                            Description = "Contains Veal",
                            Image = "Food.jpg",
                            Price = 9.50,
                            InStock = true,
                            Animal = AnimalType.Dog,
                            ItemBrand = "Purina",
                            FoodWeight = 7,
                            IsGrainFree = true,
                        },
                          new Food
                        {
                            ID = 3,
                            Name = "Duck Dry Food",
                            Description = "Contains Duck",
                            Image = "Food.jpg",
                            Price = 6.50,
                            InStock = true,
                            Animal = AnimalType.Cat,
                            ItemBrand = "Royal Canin",
                            FoodWeight = 7,
                            IsGrainFree = true,
                        },
                        new Toys
                        {
                            ID = 4,
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