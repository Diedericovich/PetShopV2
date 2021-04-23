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
            productExampleDB = new GenericRepo<Product>();

            //CartItems = new ObservableCollection<Product>();

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

    }
}