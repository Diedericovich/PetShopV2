using Microsoft.EntityFrameworkCore;
using PetShopV2.Models;
using System.IO;
using Xamarin.Essentials;

namespace PetShopV2.Services
{
    public class PetShopContext : DbContext
    {
        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<Food> FoodItems { get; set; }

        public DbSet<Toys> Toys { get; set; }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        public PetShopContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "PetShop1.SQLite");
            optionsBuilder.UseSqlite($"FileName={dbPath}");
        }
    }
}