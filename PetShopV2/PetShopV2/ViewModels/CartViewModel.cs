using PetShopV2.Models;
using PetShopV2.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;

namespace PetShopV2.ViewModels
{
    public class CartViewModel : BaseViewModel
    {
        private Product _selectedProduct;

        private ObservableCollection<Product> cartItems;

        public ObservableCollection<Product> CartItems
        {
            get { return cartItems; }
            set
            {
                cartItems = value;
                OnPropertyChanged(nameof(CartItems));
            }
        }

        public Command LoadProductsCommand { get; }
        public Command AddProductCommand { get; }
        public Command<Product> ProductTapped { get; }

        public CartViewModel()
        {
            Title = "Cart";
            CartItems = new ObservableCollection<Product>();
            ExecuteLoadProductsCommand();
            //LoadProductsCommand = new Command(async () => await ExecuteLoadProductsCommand());

            //todo: fix erboven
            LoadProductsCommand = new Command(ExecuteLoadProductsCommand);
            ProductTapped = new Command<Product>(OnProductSelected);

            AddProductCommand = new Command(OnAddProduct);
        }

        private async void ExecuteLoadProductsCommand()
        {
            IsBusy = true;

            try
            {
                //todo: not all data has to be fetched, fix this later
                CartItems.Clear();
                IEnumerable<Product> products = await DataStore.GetAllProductsAsync(true);

                List<Product> newProductList = new List<Product>();

                foreach (var product in products)
                {
                    CartItems.Add(product);

                    //if (product is Food food)
                    //{
                    //    newFoodList.Add(food);
                    //}
                }
                CartItems = new ObservableCollection<Product>(newProductList);
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
            {
                throw new ArgumentNullException(nameof(product));
            }

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(CartDetailPage)}?{nameof(CartDetailViewModel.ProductId)}={product.ID}");
        }
    }
}