using PetShopV2.Models;
using PetShopV2.Services;
using PetShopV2.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PetShopV2.ViewModels
{
    public class FoodViewModel : BaseViewModel
    {
        private IProductExampleDB<Product> productExampleDB;

        private Food _selectedProduct;

        private ObservableCollection<Food> foodItems;

        public ObservableCollection<Food> FoodItems
        {
            get { return foodItems; }
            set
            {
                foodItems = value;
                OnPropertyChanged(nameof(FoodItems));
            }
        }

        public Command LoadProductsCommand { get; }

        public Command<Food> ProductTapped { get; }

        //public Command<string> SkillDeletedCommand => new Command<string>(SkillDeleted);

        public FoodViewModel()
        {
            Title = "Food";
            FoodItems = new ObservableCollection<Food>();
            productExampleDB = new ProductExampleDB<Product>();

            //CartItems = new ObservableCollection<Product>();

            //AddDummyDataAsync();
            ExecuteLoadProductsCommand();
            //LoadProductsCommand = new Command(async () => await ExecuteLoadProductsCommand());

            //todo: fix erboven
            LoadProductsCommand = new Command(ExecuteLoadProductsCommand);
            ProductTapped = new Command<Food>(OnProductSelected);

            //AddProductCommand = new Command(OnAddProduct);
        }

        private async void ExecuteLoadProductsCommand()
        {
            IsBusy = true;

            try
            {
                //todo: not all data has to be fetched, fix this later
                FoodItems.Clear();
                IEnumerable<Product> products = await productExampleDB.GetAllProductsAsync();
                FoodItems = new ObservableCollection<Food>();
                foreach (var item in products)
                {
                    if (item is Food)
                    {
                        FoodItems.Add((Food)item);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        //public void OnAppearing()
        //{
        //    IsBusy = true;
        //    SelectedFood = null;
        //}

        public Food SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                SetProperty(ref _selectedProduct, value);
                OnProductSelected(value);
            }
        }

        private async void OnProductSelected(Food food)
        {
            if (food == null)
            {
                throw new ArgumentNullException(nameof(food));
            }

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(FoodDetailPage)}?{nameof(FoodDetailViewModel.FoodId)}={food.ID}");
        }

        private async Task AddDummyDataAsync()
        {
            var product = new List<Product>
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
            foreach (Product item in product)
            {
                if (item is Food)
                {
                    await productExampleDB.AddProductAsync((Food)item);
                }
                else if (item is Toys)
                {
                    await productExampleDB.AddProductAsync((Toys)item);
                }
            }
        }
    }
}