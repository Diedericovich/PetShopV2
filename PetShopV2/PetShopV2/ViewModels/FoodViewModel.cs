using PetShopV2.Models;
using PetShopV2.Services;
using PetShopV2.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

        public FoodViewModel()
        {
            Title = "Food";
            FoodItems = new ObservableCollection<Food>();
            productExampleDB = new GenericRepo<Product>();
            ExecuteLoadProductsCommand();
            LoadProductsCommand = new Command(ExecuteLoadProductsCommand);
            ProductTapped = new Command<Food>(OnProductSelected);
        }

        private async void ExecuteLoadProductsCommand()
        {
            IsBusy = true;
            try
            {
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

            await Shell.Current.GoToAsync($"{nameof(FoodDetailPage)}?{nameof(FoodDetailViewModel.FoodId)}={food.ID}");
        }
    }
}