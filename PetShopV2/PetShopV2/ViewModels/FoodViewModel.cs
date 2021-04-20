using PetShopV2.Models;
using PetShopV2.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PetShopV2.ViewModels
{
    public class FoodViewModel : BaseViewModel
    {
        private Product _selectedProduct;

        public ObservableCollection<Product> Products { get; }
        public Command LoadProductsCommand { get; }
        public Command AddProductCommand { get; }
        public Command<Product> ProductTapped { get; }

        public FoodViewModel()
        {
            Title = "Food";
            Products = new ObservableCollection<Product>();
            LoadProductsCommand = new Command(async () => await ExecuteLoadProductsCommand());

            ProductTapped = new Command<Product>(OnProductSelected);

            AddProductCommand = new Command(OnAddProduct);
        }

        private async Task ExecuteLoadProductsCommand()
        {
            IsBusy = true;

            try
            {
                Products.Clear();
                var products = await DataStore.GetAllProductsAsync(true);
                foreach (var product in products)
                {
                    Products.Add(product);
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

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedProduct = null;
        }

        public Product SelectedProduct
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

        private async void OnProductSelected(Product product)
        {
            if (product == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(FoodDetailPage)}?{nameof(FoodDetailViewModel.ProductID)}={product.ID}");
        }
    }
}