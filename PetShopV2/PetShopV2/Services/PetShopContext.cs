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
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "PetShop1007.SQLite");
            optionsBuilder.UseSqlite($"FileName={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedFood(modelBuilder);
            SeedToys(modelBuilder);
            SeedCart(modelBuilder);
        }

        private void SeedCart(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartItem>().HasData(
                new CartItem
                {
                    ID = 1,
                    ProductId = 1,
                    CartItemQuantity = 1,
                    CartItemTotalPrice = 4.50,
                },
                 new CartItem
                 {
                     ID = 2,
                     ProductId = 2,
                     CartItemQuantity = 1,
                     CartItemTotalPrice = 0.50,
                 },
                  new CartItem
                  {
                      ID = 3,
                      ProductId = 3,
                      CartItemQuantity = 1,
                      CartItemTotalPrice = 6.50,
                  }
                );
        }
        private void SeedFood(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Food>().HasData(

                new Food
                {
                    ID = 1,
                    Name = "Meow Mix Original Choice",
                    Description = "100% complete and balanced nutrition, all essential vitamines & minerals, high quality protein helps support strong, healthy muscles; Delicious flavours of: chicken, turkey, salmon and ocean fish",
                    Image = "Catfood_MeowMix.jpg",
                    Price = 4.50,
                    InStock = true,
                    Animal = AnimalType.Cat,
                    ProductBrand = "Made in the USA",
                    FoodWeight = 7.26,
                    IsGrainFree = true,
                },
                new Food
                {
                    ID = 2,
                    Name = "Whiskas Jelly bag with Chicken",
                    Description = "Contains Chicken in jelly; with selected natural ingredients with vitamins & minerals",
                    Image = "Catfood_Whiskas_ChickenJelly_Bag.jpg",
                    Price = 0.50,
                    InStock = true,
                    Animal = AnimalType.Cat,
                    ProductBrand = "Whiskas",
                    FoodWeight = 0.10,
                    IsGrainFree = true,
                },
                new Food
                {
                    ID = 3,
                    Name = "9 Lives Indoor Complete",
                    Description = "Targeted Nutrition for indoor adult cats; helps support a healthy immune system; helps support healthy weight & metabolism; easy litter box cleanup; 100% complete & balanced nutrition for adult cats; with flavors of chicken and salmon",
                    Image = "Catfood9lives.jpeg",
                    Price = 6.50,
                    InStock = true,
                    Animal = AnimalType.Cat,
                    ProductBrand = "9 Lives",
                    FoodWeight = 9.07,
                    IsGrainFree = true,
                },
                new Food
                {
                    ID = 4,
                    Name = "Cat Food NEW",
                    Description = "contains natural ingredients, essential nutrients & antioxidants and extra calcium; mix of chicken and dog flavors",
                    Image = "Catfood_Catfood_Mix_Can.png",
                    Price = 4.20,
                    InStock = true,
                    Animal = AnimalType.Cat,
                    ProductBrand = "Cat Food",
                    FoodWeight = 2.50,
                    IsGrainFree = false,
                },
                new Food
                {
                    ID = 5,
                    Name = "Whiskas Adult 1+ Mackerel Flavour",
                    Description = "Food for adult cats; supports the vital system: healthy and shiny coat, healthy eyesight, lively and energetic; mackerel flavour",
                    Image = "Catfood_Whiskas_MackerelFlavour_Bag.png",
                    Price = 5.50,
                    InStock = false,
                    Animal = AnimalType.Cat,
                    ProductBrand = "Whiskas",
                    FoodWeight = 7,
                    IsGrainFree = true,
                },
                new Food
                {
                    ID = 6,
                    Name = "Dog Food New",
                    Description = "Contains natural ingredients, essential nutrients & antioxidants and extra calcium; crunchy bites;  mix of cat and chicken flavors,",
                    Image = "Dogfood_New.png",
                    Price = 4.20,
                    InStock = true,
                    Animal = AnimalType.Dog,
                    ProductBrand = "Dog Food",
                    FoodWeight = 2.50,
                    IsGrainFree = false,
                },
                new Food
                {
                    ID = 7,
                    Name = "Blue Wilderness - Nature's Evolutionary Diet",
                    Description = "Natural food for adult dogs enhanced with vitamins and minerals; High Protein; Contains Chicken; 100% Grain free, ",
                    Image = "Blue_WildernessWolf.jfif",
                    Price = 6.50,
                    InStock = true,
                    Animal = AnimalType.Dog,
                    ProductBrand = "Blue Wilderness",
                    FoodWeight = 5,
                    IsGrainFree = true,
                },
                new Food
                {
                    ID = 8,
                    Name = "Quality Dog Food",
                    Description = "Food for adult dogs; all breeds",
                    Image = "Horta_QualityDogFood.png",
                    Price = 8.50,
                    InStock = true,
                    Animal = AnimalType.Dog,
                    ProductBrand = "Horta",
                    FoodWeight = 15,
                    IsGrainFree = true,
                },
                new Food
                {
                    ID = 9,
                    Name = "Pedigree Small Dog",
                    Description = "Food for small dogs including complete nutrition; Roasted Chicken, rice & vegetable flavor; 100% complete and balanced food for adult dogs, no high fructose corn syrup, no artifical flavors, no added sugar",
                    Image = "Pedigree_SmallDog.jpg",
                    Price = 7.20,
                    InStock = true,
                    Animal = AnimalType.Dog,
                    ProductBrand = "Pedigree",
                    FoodWeight = 7.20,
                    IsGrainFree = true,
                }
             );
        }
        private void SeedToys(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Toys>().HasData(
                new Toys
                {
                    ID = 20,
                    Name = "Fluffy Basket",
                    Description = "Basket for adult cat; 100% cotton; colour: blue, black, red, pink; Size: M, L, XL, XXL",
                    Image = "Basket.jpg",
                    Price = 9.90,
                    InStock = true,
                    Animal = AnimalType.Cat,
                    ProductBrand = "Sleep Inn",
                    ContainsLatex = false,
                    IsTough = true,
                    IsInteractive = false,
                    MakesSound = false,
                },
                new Toys
                {
                    ID = 21,
                    Name = "Electric Moving Fish",
                    Description = "Realistic Plush Simulation Electric Wagging Fish Cat Toy Kicker Toys, dancing fish cat toy,Funny Interactive Pets Bite Kick Supplies for Cat Kitten Kitty; rechargable with USB",
                    Image = "ElectricFish.jpeg",
                    Price = 19.99,
                    InStock = true,
                    Animal = AnimalType.Cat,
                    ProductBrand = "Fish Logistics Inc.",
                    ContainsLatex = true,
                    IsTough = true,
                    IsInteractive = true,
                    MakesSound = true,
                },
                new Toys
                {
                    ID = 22,
                    Name = "Dell Mouseware",
                    Description = "mini laptop for cats; rechargable with USB; Screensize: 10 inch, 15 inch, 20 inch; HD: 1 GB, 2 GB, 5 GB",
                    Image = "Laptop.jpg",
                    Price = 79.99,
                    InStock = true,
                    Animal = AnimalType.Cat,
                    ProductBrand = "Dell",
                    ContainsLatex = false,
                    IsTough = false,
                    IsInteractive = true,
                    MakesSound = true,
                },

                new Toys
                {
                    ID = 23,
                    Name = "Fluffy Balls",
                    Description = "three colourful balls, 100% wool",
                    Image = "FluffyBalls.jfif",
                    Price = 4.55,
                    InStock = true,
                    Animal = AnimalType.Cat,
                    ProductBrand = "Verrrritas",
                    ContainsLatex = false,
                    IsTough = false,
                    IsInteractive = false,
                    MakesSound = false,
                },

                // Dogs

                new Toys
                {
                    ID = 24,
                    Name = "Treat Dispensing Dog Toy",
                    Description = "Suitable for small to medium dogs; Smooth big egg shape makes pet can not that easy to put it in mouth and tore up; Durable Material & Easy Clean : Made by high quality ABS and polycarbonate so the toy is strong, no-toxicand and easy to clean, even food paste or other sticky things; Hold about 300 g dog treats;  ",
                    Image = "Dog_Bowl_Egg.jpg",
                    Price = 12.49,
                    InStock = true,
                    Animal = AnimalType.Dog,
                    ProductBrand = "Zellar Egg Solutions",
                    ContainsLatex = false,
                    IsTough = true,
                    IsInteractive = false,
                    MakesSound = false,
                },
                new Toys
                {
                    ID = 25,
                    Name = "Jumping Dog",
                    Description = "Jumping dog that is able to flip backwards; Color: brown, black, white, pink; works with batteries; batteries not included",
                    Image = "Jumping_Dog.jpg",
                    Price = 29.89,
                    InStock = true,
                    Animal = AnimalType.Dog,
                    ProductBrand = "Hotdog Corp",
                    ContainsLatex = false,
                    IsTough = true,
                    IsInteractive = true,
                    MakesSound = false,
                },

                new Toys
                {
                    ID = 26,
                    Name = "Jumping Dog",
                    Description = "Unique latex characters, in funky colours, which really stand! These toys are tough, safe to throw and produce great sounds which dogs find fascinating. Most toys make a loud squeaking sound, Key BenefitsTough character latex toys Safe to throw & retrieve for interactive fun With a squeak Recommended for Dogs that love to play. Material Latex Care & Use Wipe clean only",
                    Image = "Rubber_Chicken.jpg",
                    Price = 4.75,
                    InStock = true,
                    Animal = AnimalType.Dog,
                    ProductBrand = "Roughware",
                    ContainsLatex = true,
                    IsTough = true,
                    IsInteractive = false,
                    MakesSound = false,
                },
                new Toys
                {
                    ID = 27,
                    Name = "Rubber Dogbone",
                    Description = "colourful rubber dog toy; Size: S, M, L; Color: red, yellow, blue",
                    Image = "Rubber_Dogbone.jpg",
                    Price = 49.10,
                    InStock = true,
                    Animal = AnimalType.Dog,
                    ProductBrand = "KONG",
                    ContainsLatex = true,
                    IsTough = true,
                    IsInteractive = false,
                    MakesSound = false,
                },
                new Toys
                {
                    ID = 28,
                    Name = "Fluffy Yoda Doll",
                    Description = "Ideal doll for dogs training the Force; Preserved best under green TL-light",
                    Image = "Stuffed_Yoda.jpg",
                    Price = 1999.99,
                    InStock = true,
                    Animal = AnimalType.Dog,
                    ProductBrand = "Disney Toys",
                    ContainsLatex = false,
                    IsTough = false,
                    IsInteractive = false,
                    MakesSound = false,
                }
             );
        }

    }
}