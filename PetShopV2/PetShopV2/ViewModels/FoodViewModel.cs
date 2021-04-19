using PetShopV2.Models;
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
            Title = "Products";
            Products = new ObservableCollection<Product>();
            LoadProductsCommand = new Command(async () => await ExecuteLoadProductsCommand());

            ProductTapped = new Command<Item>(OnProductSelected);

            AddProductCommand = new Command(OnAddProduct);
        }

        async Task ExecuteLoadProductsCommand()
        {
            IsBusy = true;

            try
            {
                Products.Clear();
                var products = await DataStore.GetProductsAsync(true);
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

        private async void OnAddProduct(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewFoodPage));
        }

        async void OnProductSelected(Product product)
        {
            if (product == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(FoodDetailPage)}?{nameof(FoodDetailViewModel.ProductID)}={product.ID}");
        }
    }
}
