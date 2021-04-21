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
        private IProductExampleDB<Food> productExampleDB;

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
        public Command AddProductCommand { get; }
        public Command<Food> ProductTapped { get; }

        public FoodViewModel()
        {
            Title = "Food";
            FoodItems = new ObservableCollection<Food>();
            productExampleDB = new ProductExampleDB<Food>();
            // AddDummyDataAsync();
            ExecuteLoadProductsCommand();
            //LoadProductsCommand = new Command(async () => await ExecuteLoadProductsCommand());

            //todo: fix erboven
            LoadProductsCommand = new Command(ExecuteLoadProductsCommand);
            ProductTapped = new Command<Food>(OnProductSelected);

            AddProductCommand = new Command(OnAddProduct);
        }

        private async void ExecuteLoadProductsCommand()
        {
            IsBusy = true;

            try
            {
                //todo: not all data has to be fetched, fix this later
                FoodItems.Clear();
                IEnumerable<Food> products = await productExampleDB.GetAllProductsAsync();
                FoodItems = new ObservableCollection<Food>(products);
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

        //deze methode gbruiken om product aan shoppingcart toe te voegen.
        // "Newfoodpage" nog vervangen

        private async void OnAddProduct(object obj)
        {
            //  await Shell.Current.GoToAsync(nameof(NewFoodPage));
        }

        //deze methode gbruiken om door te klikken naar de detailview van het product
        // "FoodDetailPage" nog vervangen

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
            var product = new Food
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
            };
            await productExampleDB.AddProductAsync(product);
        }
    }
}