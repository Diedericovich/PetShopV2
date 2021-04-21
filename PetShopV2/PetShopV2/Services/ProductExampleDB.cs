using PetShopV2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopV2.Services
{
    public class ProductExampleDB<T> : IProductExampleDB<T> where T : Product
    {
        private List<T> products;

        public ProductExampleDB()
        {
            if (products == null)
            {
                AddDummyData();
            }
        }

        public async Task<bool> AddProductAsync(T product)
        {
            products.Add(product);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var oldItem = products.FirstOrDefault(x => x.ID == id);
            products.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public List<T> GetAllProducts()
        {
            return products;
        }

        public async Task<T> GetProductAsync(int id)
        {
            return await Task.FromResult(products.FirstOrDefault(s => s.ID == id));
        }

        public async Task<IEnumerable<T>> GetAllProductsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(products);
        }

        public async Task<bool> UpdateProductAsync(T product)
        {
            var oldItem = products.FirstOrDefault(x => x.ID == product.ID);
            products.Remove(oldItem);
            products.Add(product);

            return await Task.FromResult(true);
        }

        private List<Product> AddDummyData()
        {
            return new List<Product>
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
                            ProductBrand = "Whiskas",
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
                            ProductBrand = "Purina",
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
                            ProductBrand = "Royal Canin",
                            FoodWeight = 7,
                            IsGrainFree = true,
                        },
                        new Toys
                        {
                            ID = 4,
                            Name = "Dog Ball",
                            Description = "a colourful rubber ball which makes lot of sound and noise",
                            Image = "Toys.jpg",
                            Price = .75,
                            InStock = true,
                            Animal = AnimalType.Dog,
                            ProductBrand = "Roughware",
                            ContainsLatex = true,
                            IsTough = true,
                            IsInteractive = true,
                            MakesSound = true,
                        },
                        new Toys
                        {
                            ID = 5,
                            Name = "Second Dog Ball",
                            Description = "also a colourful rubber ball",
                            Image = "Toys.jpg",
                            Price = 1,
                            InStock = true,
                            Animal = AnimalType.Dog,
                            ProductBrand = "Roughware",
                            ContainsLatex = true,
                            IsTough = true,
                            IsInteractive = true,
                            MakesSound = true,
                        },
                        new Toys
                        {
                            ID = 6,
                            Name = "Third Dog Ball",
                            Description = "is it the same or not, who knows",
                            Image = "Toys.jpg",
                            Price = 9000,
                            InStock = true,
                            Animal = AnimalType.Dog,
                            ProductBrand = "Roughware",

                            ContainsLatex = true,
                            IsTough = true,
                            IsInteractive = true,
                            MakesSound = true,
                        }
                };
        }
    }
}