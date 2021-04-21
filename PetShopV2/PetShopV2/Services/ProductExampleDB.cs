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

        public ProductExampleDB()
        {
            if (products == null)
            {
                AddDummyData();
            }
        }

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