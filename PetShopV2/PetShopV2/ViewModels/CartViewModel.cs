using PetShopV2.Models;
using PetShopV2.Services;
using PetShopV2.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;

namespace PetShopV2.ViewModels
{
    public class CartViewModel : BaseViewModel
    {
        private Product _selectedProduct;

        public Command LoadProductsCommand { get; }

        public Command<CartItem> AddProductCommand => new Command<CartItem>(OnAddProduct);

        public Command<CartItem> DeductProductCommand => new Command<CartItem>(OnDeductProduct);

        public Command<Product> ProductTapped { get; }

        //public Command DeleteProductCommand => new Command(OnDeleteProduct);

        public Command<CartItem> DeleteProductCommand { get; set; }

        public CartViewModel()
        {
            Title = "Cart";
            //LoadProductsCommand = new Command(async () => await ExecuteLoadProductsCommand());
            CartSingleton cartSingleton = CartSingleton.GetSingleton();

            //todo: fix erboven
            //LoadProductsCommand = new Command(ExecuteLoadProductsCommand);
            ProductTapped = new Command<Product>(OnProductSelected);
            DeleteProductCommand = new Command<CartItem>(OnDeleteProduct);
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

        private async void OnProductSelected(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(CartDetailPage)}?{nameof(CartDetailViewModel.ProductId)}={product.ID}");
        }

        private void OnAddProduct(CartItem cartItem)
        {
            CartSingleton.ShoppingCart.ItemsInCart.FirstOrDefault(x => x == cartItem).CartItemQuantity += 1;
        }

        private void OnDeductProduct(CartItem cartItem)
        {
            if (cartItem.CartItemQuantity > 1)
            {
                //cartItem.CartItemQuantity -= 1;
                CartSingleton.ShoppingCart.ItemsInCart.FirstOrDefault(x => x == cartItem).CartItemQuantity -= 1;
            }
        }


        private void OnDeleteProduct(CartItem cartItem)
        {
            //var Cart2 = CartSingleton.GetSingleton();
            //var Cart = Cart2.ShoppingCart.ItemsInCart;

            ////product = _selectedProduct;
            

            //cartItem = new CartItem()
            //{
            //    Product = _selectedProduct,
            //    ProductId = _selectedProduct.ID,
            //};

            CartSingleton.ShoppingCart.ItemsInCart.Remove(cartItem);

        }

    }
}